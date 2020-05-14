using HotelFinder.Business.Abstract;
using HotelFinder.DAL.Abstract;
using HotelFinder.DAL.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private IHotelRepo _hotelRepo;

        public HotelManager(IHotelRepo hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            return await _hotelRepo.CreateHotel(hotel);
        }

        public async Task DeleteHotel(int id)
        {
            if (id > 0)
            {
               await _hotelRepo.DeleteHotel(id);
            }

            throw new Exception("id değeri sıfırdan büyük olmalıdır");
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _hotelRepo.GetAllHotels();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            return await _hotelRepo.GetHotelById(id);
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            if(name !=null && name != "")
            {
                return await _hotelRepo.GetHotelByName(name);
            }
            throw new Exception("name alanı boş");
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await _hotelRepo.UpdateHotel(hotel);
        }
    }
}
