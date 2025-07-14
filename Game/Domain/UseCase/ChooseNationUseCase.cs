using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DominionProtocol.Domain.Model;
using DominionProtocol.Domain.Repository;

namespace DominionProtocol.Domain.UseCase;

public class ChooseNationUseCase : IChooseNationUseCase
{
    private readonly INationRepository _nationRepository;
    private readonly IGameSettingsRepository _settingsRepository;

    public ChooseNationUseCase(INationRepository nationRepository, IGameSettingsRepository settingsRepository)
    {
        _nationRepository = nationRepository;
        _settingsRepository = settingsRepository;
    }

    public async Task<List<Nation>> GetAvailableNations()
    {
        var current = _settingsRepository.Load();
        if (current == null)
            throw new InvalidOperationException("Game settings not initialized.");

        if (current.Period == null)
            throw new InvalidOperationException("Period not selected.");
            
        return await _nationRepository.GetAvailableForPeriod(current.Period.Value);
    }

    public void SelectNation(Nation nation)
    {
        var current = _settingsRepository.Load();
        if (current == null)
            throw new InvalidOperationException("Game settings not initialized.");
        _settingsRepository.Save(current.WithNation(nation));
    }
}
