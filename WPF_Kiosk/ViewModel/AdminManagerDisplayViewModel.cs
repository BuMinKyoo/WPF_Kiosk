using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;

namespace WPF_Kiosk.ViewModel
{
    public class AdminManagerDisplayViewModel : INotifyPropertyChanged
    {
        public AdminManagerDisplayViewModel()
        {
            WeakReferenceMessenger.Default.Register<CustomMessage>(this, ReceiveMessage);
            WeakReferenceMessenger.Default.Register<CustomEvent>(this, ReceiveEvent);
        }

        private void ReceiveMessage(object recipient, CustomMessage message)
        {
            if (message.EventName == "AdminManagerDisplayViewModel-BlAdminManagerVis")
            {
                BlAdminManagerVis = (bool)message.Message;
            }
        }

        private void ReceiveEvent(object recipient, CustomEvent message)
        {
            if (message.EventName == "AdminManagerDisplayViewModel-GetPwId")
            {
                GetPwId();
            }
        }

        private async void GetPwId()
        {
            // Get방식
            try
            {
                // HttpClient 인스턴스 생성
                using (HttpClient client = new HttpClient())
                {
                    // GET 요청 보내기
                    HttpResponseMessage response = await client.GetAsync("http://220.118.53.92:5001/IDPW");

                    // 응답 확인
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        MessageBox.Show($"HTTP 오류 코드: {response.StatusCode}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool _blAdminManagerVis = false;
        public bool BlAdminManagerVis
        {
            get { return _blAdminManagerVis; }
            set
            {
                _blAdminManagerVis = value;
                Notify();
            }
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Notify([CallerMemberName] string? propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
