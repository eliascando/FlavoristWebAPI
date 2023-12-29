using Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class OTPService
        : IServiceOTP<Guid>
    {

        private const int OtpSize = 6; // Tamaño del OTP en dígitos
        private const int Interval = 60; // Intervalo en segundos para cada OTP
        private static readonly string UsedOtpFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.dat");

        public string GenerarOTP(Guid id)
        {
            string secretKey = GenerateBase64Key(id.ToString());
            long timestep = GetCurrentTimeStepNumber();
            byte[] timestepBytes = BitConverter.GetBytes(timestep);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(timestepBytes);
            }

            byte[] keyBytes = Encoding.ASCII.GetBytes(secretKey);
            byte[] hash;

            using (HMACSHA1 hmac = new HMACSHA1(keyBytes))
            {
                hash = hmac.ComputeHash(timestepBytes);
            }

            int offset = hash[hash.Length - 1] & 0x0F;
            int binaryCode = (hash[offset] & 0x7F) << 24
                | (hash[offset + 1] & 0xFF) << 16
                | (hash[offset + 2] & 0xFF) << 8
                | (hash[offset + 3] & 0xFF);

            int otp = binaryCode % (int)Math.Pow(10, OtpSize);
            return otp.ToString().PadLeft(OtpSize, '0');
        }

        public bool ValidarOTP(Guid id, string otp)
        {
            string expectedOtp = GenerarOTP(id);
            var usedOtps = ReadUsedOtps();

            string key = $"{id}-{otp}";
            if (otp == expectedOtp && !usedOtps.ContainsKey(key))
            {
                usedOtps[key] = DateTime.UtcNow;
                WriteUsedOtps(usedOtps);
                return true;
            }

            return false;
        }

        private Dictionary<string, DateTime> ReadUsedOtps()
        {
            var usedOtps = new Dictionary<string, DateTime>();
            if (File.Exists(UsedOtpFilePath))
            {
                var lines = File.ReadAllLines(UsedOtpFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { ',' }, 2);
                    if (parts.Length == 2 && DateTime.TryParse(parts[1], out var time))
                    {
                        usedOtps[parts[0]] = time;
                    }
                }
            }
            return usedOtps;
        }

        private void WriteUsedOtps(Dictionary<string, DateTime> usedOtps)
        {
            var lines = usedOtps.Select(kvp => $"{kvp.Key},{kvp.Value}");
            File.WriteAllLines(UsedOtpFilePath, lines);
        }
        private static string GenerateBase64Key(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            string base64Key = Convert.ToBase64String(bytes);
            return base64Key;
        }
        private static long GetCurrentTimeStepNumber()
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = (long)(DateTime.UtcNow - epoch).TotalSeconds;
            return timestamp / Interval;
        }
    }
}
