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
using System.Threading.Tasks;
using Xunit;

namespace VatanSms.Tests
{
    public class VatanSmsClientTests
    {
        [Fact]
        public async Task SendSmsAsync_ShouldThrowException_OnInvalidApiKey()
        {
            var client = new VatanSmsClient("invalid_api_id", "invalid_api_key");

            var phones = new List<string> { "5xxxxxxxxx" };
            var message = "Test mesajı";
            var sender = "TEST";

            await Assert.ThrowsAsync<VatanSmsException>(async () =>
                await client.SendSmsAsync(phones, message, sender));
        }

        [Fact]
        public async Task SendNtoNSmsAsync_ShouldThrowException_OnInvalidApiKey()
        {
            var client = new VatanSmsClient("invalid_api_id", "invalid_api_key");

            var phones = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "phone", "5xxxxxxxxx" },
                    { "message", "Test mesajı" }
                }
            };
            var sender = "TEST";

            await Assert.ThrowsAsync<VatanSmsException>(async () =>
                await client.SendNtoNSmsAsync(phones, sender));
        }

        [Fact]
        public async Task GetSenderNamesAsync_ShouldThrowException_OnInvalidApiKey()
        {
            var client = new VatanSmsClient("invalid_api_id", "invalid_api_key");

            await Assert.ThrowsAsync<VatanSmsException>(async () =>
                await client.GetSenderNamesAsync());
        }

        [Fact]
        public async Task GetUserInformationAsync_ShouldThrowException_OnInvalidApiKey()
        {
            var client = new VatanSmsClient("invalid_api_id", "invalid_api_key");

            await Assert.ThrowsAsync<VatanSmsException>(async () =>
                await client.GetUserInformationAsync());
        }

        [Fact]
        public async Task GetReportDetailAsync_ShouldThrowException_OnInvalidApiKey()
        {
            var client = new VatanSmsClient("invalid_api_id", "invalid_api_key");

            await Assert.ThrowsAsync<VatanSmsException>(async () =>
                await client.GetReportDetailAsync(123));
        }

        [Fact]
        public async Task GetReportsByDateAsync_ShouldThrowException_OnInvalidApiKey()
        {
            var client = new VatanSmsClient("invalid_api_id", "invalid_api_key");

            await Assert.ThrowsAsync<VatanSmsException>(async () =>
                await client.GetReportsByDateAsync("2025-01-01 00:00:00", "2025-01-07 23:59:59"));
        }

        [Fact]
        public async Task GetReportStatusAsync_ShouldThrowException_OnInvalidApiKey()
        {
            var client = new VatanSmsClient("invalid_api_id", "invalid_api_key");

            await Assert.ThrowsAsync<VatanSmsException>(async () =>
                await client.GetReportStatusAsync(123));
        }

        [Fact]
        public async Task CancelFutureSmsAsync_ShouldThrowException_OnInvalidApiKey()
        {
            var client = new VatanSmsClient("invalid_api_id", "invalid_api_key");

            await Assert.ThrowsAsync<VatanSmsException>(async () =>
                await client.CancelFutureSmsAsync(123));
        }
    }
}
