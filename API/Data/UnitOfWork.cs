﻿using API.Interfaces;
using AutoMapper;

namespace API.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UnitOfWork(DataContext dataContext, IMapper mapper)
    {
        _context = dataContext;
        _mapper = mapper;
    }
    public IUserRepository UserRepository => new UserRepository(_context, _mapper);

    public IMessageRepository MessageRepository => new MessageRepository(_context, _mapper);

    public ILikesRepository LikesRepository => new LikesRepository(_context);

    public IPhotoRepository PhotoRepository => new PhotoRepository(_context);

    public async Task<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }
}
