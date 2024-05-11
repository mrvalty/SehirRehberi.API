using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Data
{
    public class AppRepository : IAppRepository
    {
        private DataContext _context;

        public AppRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity)
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        public List<City> GetCities()
        {
            var cities = _context.Cities.Include(x=>x.Photos).ToList();
            return cities;
        }

        public City GetCityById(int CityId)
        {
            var citie = _context.Cities.Include(x => x.Photos).Where(x => x.Id == CityId).FirstOrDefault();
            return citie;
        }

        public Photo GetPhoto(int id)
        {
            var photo = _context.Photos.Where(x => x.Id == id).FirstOrDefault();

            return photo;
        }

        public List<Photo> GetPhotosByCity(int cityId)
        {
            var photos = _context.Photos.Where(x => x.CityId == cityId).ToList();

            return photos;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
