/**
 * VatanSMS ASP.NET SDK
 * Developed by Timur (https://github.com/lyreq)
 * 
 * This SDK allows you to interact with the VatanSMS.Net API seamlessly.
 * For more details, visit https://vatansms.net
 * 
 * License: MIT
 */
 
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VatanSms
{
    public class VatanSmsClient
    {
        private readonly string _apiId;
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;

        public VatanSmsClient(string apiId, string apiKey, string baseUrl = "https://api.toplusmspaketleri.com/api/v1")
        {
            _apiId = apiId ?? throw new ArgumentNullException(nameof(apiId));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _baseUrl = baseUrl.TrimEnd('/');
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// 1-to-N SMS Gönderimi
        /// </summary>
        public async Task<string> SendSmsAsync(List<string> phones, string message, string sender, string messageType = "normal", string messageContentType = "bilgi", DateTime? sendTime = null)
        {
            var payload = new
            {
                api_id = _apiId,
                api_key = _apiKey,
                sender,
                message_type = messageType,
                message,
                message_content_type = messageContentType,
                phones,
                send_time = sendTime?.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return await SendRequestAsync("/1toN", payload);
        }

        /// <summary>
        /// N-to-N SMS Gönderimi
        /// </summary>
        public async Task<string> SendNtoNSmsAsync(List<Dictionary<string, string>> phones, string sender, string messageType = "turkce", string messageContentType = "bilgi", DateTime? sendTime = null)
        {
            var payload = new
            {
                api_id = _apiId,
                api_key = _apiKey,
                sender,
                message_type = messageType,
                message_content_type = messageContentType,
                phones,
                send_time = sendTime?.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return await SendRequestAsync("/NtoN", payload);
        }

        /// <summary>
        /// Gönderici Adlarını Sorgulama
        /// </summary>
        public async Task<string> GetSenderNamesAsync()
        {
            var payload = new
            {
                api_id = _apiId,
                api_key = _apiKey
            };

            return await SendRequestAsync("/senders", payload);
        }

        /// <summary>
        /// Kullanıcı Bilgilerini Sorgulama
        /// </summary>
        public async Task<string> GetUserInformationAsync()
        {
            var payload = new
            {
                api_id = _apiId,
                api_key = _apiKey
            };

            return await SendRequestAsync("/user/information", payload);
        }

        /// <summary>
        /// Rapor Sorgulama - Rapor Detayı
        /// </summary>
        public async Task<string> GetReportDetailAsync(int reportId, int page = 1, int pageSize = 20)
        {
            var payload = new
            {
                api_id = _apiId,
                api_key = _apiKey,
                report_id = reportId
            };

            string endpoint = $"/report/detail?page={page}&pageSize={pageSize}";
            return await SendRequestAsync(endpoint, payload);
        }

        /// <summary>
        /// Rapor Sorgulama - Tarih Bazlı
        /// </summary>
        public async Task<string> GetReportsByDateAsync(string startDate, string endDate)
        {
            var payload = new
            {
                api_id = _apiId,
                api_key = _apiKey,
                start_date = startDate,
                end_date = endDate
            };

            return await SendRequestAsync("/report/between", payload);
        }

        /// <summary>
        /// Rapor Sorgulama - Sonuç Sorgusu
        /// </summary>
        public async Task<string> GetReportStatusAsync(int reportId)
        {
            var payload = new
            {
                api_id = _apiId,
                api_key = _apiKey,
                report_id = reportId
            };

            return await SendRequestAsync("/report/single", payload);
        }

        /// <summary>
        /// İleri Tarihli SMS İptali
        /// </summary>
        public async Task<string> CancelFutureSmsAsync(int id)
        {
            var payload = new
            {
                api_id = _apiId,
                api_key = _apiKey,
                id
            };

            return await SendRequestAsync("/cancel/future-sms", payload);
        }

        /// <summary>
        /// HTTP POST İsteği
        /// </summary>
        private async Task<string> SendRequestAsync(string endpoint, object payload)
        {
            var jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}{endpoint}", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new VatanSmsException($"HTTP Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
