using Phoenix.Models;

namespace Phoenix.Services.Interfaces
{
    internal interface IConfigurationService
    {
        Configuration Configuration { get; }

        void Save();

        void Load();
    }
}