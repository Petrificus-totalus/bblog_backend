using blog.Dtos.AlgoTag;
using blog.Models;

namespace blog.Mappers;

public  static class AlgoLabelMapper
{
    public static AlgoLabelDto ToAlgoLabelDto(this Label labelModel)
    {
        return new AlgoLabelDto
        {
            Id = labelModel.Id,
            Name = labelModel.Name,
            
        };
    }
}