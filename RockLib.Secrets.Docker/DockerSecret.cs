using System.IO;

namespace RockLib.Secrets.Docker
{
    /// <summary>
    /// An implementation of the <see cref="ISecret"/> interface for use with Docker.
    /// </summary>
    public class DockerSecret : ISecret
    {
        private const string DOCKER_SECRET_PATH = "/run/secrets/";
        public DockerSecret(string configurationKey, string secretId)
        {
            ConfigurationKey = configurationKey;
            SecretId = secretId;
        }

        public string ConfigurationKey { get; }
        public string SecretId { get; }

        public string GetValue()
        {
            if (string.IsNullOrEmpty(SecretId))
                return null;

            if (Directory.Exists(DOCKER_SECRET_PATH) && File.Exists(Path.Combine(DOCKER_SECRET_PATH, SecretId)))
            {
                return File.ReadAllText(Path.Combine(DOCKER_SECRET_PATH, SecretId));
            }

            return null;
        }
    }
}
