using blog.Dtos.Algorithm;
using blog.Models;

namespace blog.Mappers;

public static class AlgorithmMapper
{
    public static AlgorithmDto ToAlgorithmDto(this Algorithm algorithmModel)
    {
        return new AlgorithmDto
        {
            Id = algorithmModel.Id,
            Desc = algorithmModel.Desc,
            Labels = algorithmModel.AlgoLabels.Select(c=>c.Label.ToAlgoLabelDto()).ToList(),
        };
    }
    public static Algorithm ToAlgorithmFromCreateAlgorithmDto(this CreateAlgorithmDto algorithmdto)
    {
        return new Algorithm
        {
            Desc = algorithmdto.Desc,
            Content = algorithmdto.Content,
        };
    }
}