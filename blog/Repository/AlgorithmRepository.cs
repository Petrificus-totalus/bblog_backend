using blog.Data;
using blog.Dtos;
using blog.Dtos.Algorithm;
using blog.Interfaces;
using blog.Mappers;
using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.Repository;

public class AlgorithmRepository: IAlgorithmRepository
{
    
    private readonly ApplicationDBContext _context;
    public AlgorithmRepository(ApplicationDBContext DBContext)
    {
        _context = DBContext;
    }
    
    public async Task<PagedResultDto<AlgorithmDto>> GetAllAsync(int pageNumber, int pageSize)
    {
        int totalRecords = await _context.Algorithms.CountAsync();
        // 计算总页数
        int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        var data = await _context.Algorithms
            .Include(c => c.AlgoLabels)
            .ThenInclude(c => c.Label)
            .Skip((pageNumber - 1) * pageSize) // 跳过前面的记录
            .Take(pageSize) // 获取指定数量的记录
            .Select(g => g.ToAlgorithmDto()) // 转换为 DTO
            .ToListAsync();

        // 返回封装的结果
        return new PagedResultDto<AlgorithmDto>
        {
            TotalPages = totalPages,
            Data = data
        };
    }

    public async Task<Algorithm?> GetByIdAsync(int id)
    {
        return await _context.Algorithms.FindAsync(id);
    }

    public async Task<Algorithm> CreateAsync(Algorithm algorithmModel)
    {
        await  _context.Algorithms.AddAsync(algorithmModel);
        await _context.SaveChangesAsync();
        return algorithmModel;
    }

    public async Task<Algorithm?> UpdateAsync(int id, UpdateAlgorithmDto algorithmDto)
    {
        var algorithm = await _context.Algorithms.FirstOrDefaultAsync(x=>x.Id == id);
        if(algorithm == null) return null;
        algorithm.Desc = algorithmDto.Desc;
        algorithm.Content = algorithmDto.Content;
        await _context.SaveChangesAsync();
        return algorithm;
    }

    public async Task<Algorithm?> DeleteAsync(int id)
    {
        var algorithm = await _context.Algorithms.FirstOrDefaultAsync(x=>x.Id == id);
        if(algorithm == null) return null;
        _context.Algorithms.Remove(algorithm);
        await _context.SaveChangesAsync();
        return algorithm;
    }
}