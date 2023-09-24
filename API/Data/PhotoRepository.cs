using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class PhotoRepository : IPhotoRepository
{
    private readonly DataContext _context;

    public PhotoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Photo> GetPhotoById(int photoId)
    {
        return await _context.Photos
            .IgnoreQueryFilters()
            .SingleOrDefaultAsync(p => p.Id == photoId);
    }

    public async Task<IEnumerable<PhotoForApprovalDto>> GetUnapprovedPhotos()
    {
        return await _context.Photos
        .IgnoreQueryFilters()
        .Where(p => p.IsApproved == false)
        .Select(u => new PhotoForApprovalDto
        {
            Id = u.Id,
            Url = u.Url,
            Username = u.AppUser.UserName,
            IsApproved = u.IsApproved
        }).ToListAsync();
    }

    public async Task<AppUser> GetUserByPhotoId(int photoId)
    {
        return await _context.Users
            .Include(p => p.Photos)
            .IgnoreQueryFilters()
            .Where(p => p.Photos.Any(p => p.Id == photoId))
            .FirstOrDefaultAsync();               
    }

    public void RemovePhoto(Photo photo)
    {
        _context.Photos.Remove(photo);
    }
}
