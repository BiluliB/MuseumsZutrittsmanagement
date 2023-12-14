using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MuseumsZutrittMauiApp.DTO.Request;
using Microsoft.Maui.Graphics;
using MuseumsZutrittMauiApp.DTO.Response;
using System.Net.Http.Json;
using System.Diagnostics;

namespace MuseumsZutrittMauiApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MuseumAreaResponse> MuseumAreas { get; private set; }
        private VisitorCapacityResponse _selectedVisitorCapacity;
        public VisitorCapacityResponse SelectedVisitorCapacity
        {
            get => _selectedVisitorCapacity;
            set
            {
                _selectedVisitorCapacity = value;
                OnPropertyChanged(nameof(SelectedVisitorCapacity));
                UpdateUI();
            }
        }
        public int CurrentVisitorCount { get; private set; }
        public Color IndicatorColor { get; private set; }
        public ICommand EintrittCommand { get; private set; }
        public ICommand AustrittCommand { get; private set; }
        public bool CanEnter => SelectedVisitorCapacity != null && CurrentVisitorCount < SelectedVisitorCapacity.MaxVisitorCount;
        public bool CanExit => CurrentVisitorCount > 0;
        private MuseumAreaResponse _selectedMuseumArea;
        public MuseumAreaResponse SelectedMuseumArea
        {
            get => _selectedMuseumArea;
            set
            {
                if (_selectedMuseumArea != value)
                {
                    _selectedMuseumArea = value;
                    OnSelectedMuseumAreaChanged();
                    OnPropertyChanged(nameof(SelectedMuseumArea));
                }
            }
        }

        private HttpClient _httpClient = new HttpClient();

        public MainPageViewModel()
        {
            MuseumAreas = new ObservableCollection<MuseumAreaResponse>();
            EintrittCommand = new Command(OnEintritt);
            AustrittCommand = new Command(OnAustritt);
            IndicatorColor = Colors.Green;
            LoadMuseumAreas();
        }

        /// <summary>
        /// Handles the entry action when a visitor enters the museum area.
        /// </summary>
        private async void OnEintritt()
        {
            var newLogEntry = new CreateAccessLogRequest
            {
                MuseumAreaId = SelectedMuseumArea.Id,
                EntryTime = DateTime.Now,
                ExitTime = DateTime.Now,
                CurrentVisitorCount = CurrentVisitorCount + 1
            };

            var response = await _httpClient.PostAsJsonAsync("https://localhost:5000/api/AccessLog", newLogEntry);
            if (response.IsSuccessStatusCode)
            {
                CurrentVisitorCount++;
                OnPropertyChanged(nameof(CurrentVisitorCount));
                UpdateUI();
            }
            else
            {
                HandleErrorResponse(response);
            }
        }

        /// <summary>
        /// Handles the exiting action when a visitor leaves the museum area.
        /// </summary>
        private async void OnAustritt()
        {
            if (CurrentVisitorCount > 0)
            {
                var newLogEntry = new CreateAccessLogRequest
                {
                    MuseumAreaId = SelectedMuseumArea.Id,
                    EntryTime = DateTime.Now,
                    ExitTime = DateTime.Now,
                    CurrentVisitorCount = CurrentVisitorCount - 1
                };

                var response = await _httpClient.PostAsJsonAsync("https://localhost:5000/api/AccessLog", newLogEntry);
                if (response.IsSuccessStatusCode)
                {
                    CurrentVisitorCount--;
                    OnPropertyChanged(nameof(CurrentVisitorCount));
                    UpdateUI();
                }
                else
                {
                    HandleErrorResponse(response);
                }
            }
        }

        /// <summary>
        /// Loads the list of museum areas from the server.
        /// </summary>
        private async void LoadMuseumAreas()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<MuseumAreaResponse>>("https://localhost:5000/api/MuseumArea");
                if (response != null)
                {
                    MuseumAreas.Clear();
                    foreach (var area in response)
                    {
                        MuseumAreas.Add(area);
                    }
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(ex);
            }
        }

        /// <summary>
        /// Handles actions when a new museum area is selected.
        /// </summary>
        private async void OnSelectedMuseumAreaChanged()
        {
            if (SelectedMuseumArea != null)
            {
                var capacity = await FetchVisitorCapacity(SelectedMuseumArea.Id);
                SetSelectedVisitorCapacity(capacity);

                CurrentVisitorCount = await FetchCurrentVisitorCount(SelectedMuseumArea.Id);

                // Notify the UI that the CurrentVisitorCount has changed
                OnPropertyChanged(nameof(CurrentVisitorCount));
                UpdateUI();
            }
        }

        /// <summary>
        /// Fetches the visitor capacity for a specific museum area identified by its ID.
        /// </summary>
        /// <param name="areaId">The ID of the museum area for which the capacity is to be fetched.</param>
        /// <returns>A VisitorCapacityResponse object representing the visitor capacity of the specified area.</returns>
        private async Task<VisitorCapacityResponse> FetchVisitorCapacity(int areaId)
        {
            try
            {
                var capacities = await _httpClient.GetFromJsonAsync<List<VisitorCapacityResponse>>("https://localhost:5000/api/VisitorCapacity");
                return capacities?.FirstOrDefault(vc => vc.MuseumAreaId == areaId);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(ex);
            }
            return null;
        }

        /// <summary>
        /// Retrieves the current visitor count for a specified museum area.
        /// </summary>
        /// <param name="areaId">The ID of the museum area for which the current visitor count is to be fetched.</param>
        /// <returns>The current number of visitors in the specified museum area.</returns>
        private async Task<int> FetchCurrentVisitorCount(int areaId)
        {
            try
            {
                var accessLogs = await _httpClient.GetFromJsonAsync<List<AccessLogResponse>>("https://localhost:5000/api/AccessLog");
                var lastLog = accessLogs?.Where(log => log.MuseumAreaId == areaId).OrderByDescending(log => log.EntryTime).FirstOrDefault();
                return lastLog != null ? lastLog.CurrentVisitorCount : 0;
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(ex);
            }
            return 0;
        }

        /// <summary>
        /// Sets the selected visitor capacity for the current museum area.
        /// </summary>
        /// <param name="capacity">The visitor capacity response object to be set.</param>
        private void SetSelectedVisitorCapacity(VisitorCapacityResponse capacity)
        {
            _selectedVisitorCapacity = capacity;
            OnPropertyChanged(nameof(SelectedVisitorCapacity));
        }

        /// <summary>
        /// Updates the user interface based on the current visitor count and selected visitor capacity.
        /// </summary>
        private void UpdateUI()
        {
            if (SelectedVisitorCapacity != null && CurrentVisitorCount != null)
            {
                IndicatorColor = CurrentVisitorCount >= SelectedVisitorCapacity.MaxVisitorCount ? Colors.Red : Colors.Green;
                OnPropertyChanged(nameof(CanEnter));
                OnPropertyChanged(nameof(CanExit));
            }
            else
            {
                IndicatorColor = Colors.Green;
                OnPropertyChanged(nameof(CanEnter));
                OnPropertyChanged(nameof(CanExit));
            }

            OnPropertyChanged(nameof(IndicatorColor));
            OnPropertyChanged(nameof(CanEnter));
            OnPropertyChanged(nameof(CanExit));
        }

        /// <summary>
        /// Handles the HTTP error response from the server.
        /// </summary>
        /// <param name="response">The HttpResponseMessage received from the server.</param>
        private async void HandleErrorResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                // Log the error
                Debug.WriteLine($"Error {response.StatusCode}: {response.ReasonPhrase}");

                // Inform the user
                await Application.Current.MainPage.DisplayAlert(
                    "Fehler",
                    $"Es gab ein Problem bei der Kommunikation mit dem Server: {response.ReasonPhrase}",
                    "OK"
                );
            }
        }

        /// <summary>
        /// Handles exceptions thrown during API calls.
        /// </summary>
        /// <param name="ex">The exception that was thrown.</param>
        private async Task HandleExceptionAsync(Exception ex)
        {
            // Log the exception
            Debug.WriteLine($"Exception: {ex.Message}");

            // Inform the user
            await Application.Current.MainPage.DisplayAlert(
                "Fehler",
                $"Ein Fehler ist aufgetreten: {ex.Message}",
                "OK"
            );
        }

        // Event handler for the PropertyChanged Events
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}