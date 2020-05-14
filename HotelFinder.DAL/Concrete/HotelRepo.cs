using HotelFinder.DAL.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DAL.Concrete
{
    public class HotelRepo : IHotelRepo
    {
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                await  hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }

        public async Task DeleteHotel(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                var deletedHotel = await GetHotelById(id);
                if(deletedHotel != null)
                {
                    hotelDbContext.Hotels.Remove(deletedHotel);
                   await hotelDbContext.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
           using(var hotelDbContext=new HotelDbContext())
            {
                return await hotelDbContext.Hotels.ToListAsync();
            }
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                //id alanı primarykey olduğu için find kullandık yoksa firstordefalt
                return await hotelDbContext.Hotels.FindAsync(id);
            }
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                //id alanı primarykey olduğu için find kullandık yoksa firstordefalt
                return await hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Update(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }
    }
}
