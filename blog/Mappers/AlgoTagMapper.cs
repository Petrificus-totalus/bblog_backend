using blog.Dtos.AlgoTag;
using blog.Models;

namespace blog.Mappers;

public  static class AlgoTagMapper
{
    public static AlgoTagDto ToAlgoTagDto(this AlgoTag algoTagModel)
    {
        return new AlgoTagDto
        {
            Id = algoTagModel.Id,
            Name = algoTagModel.Name,
            AlgorithmId = algoTagModel.AlgorithmId,
        };
    }
}