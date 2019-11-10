using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;
using HotelManagementSystem.Models.ViewModel;
using Newtonsoft.Json;

namespace HotelManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly HotelContext _context;

        public OrderController(HotelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Payment()
        {
            ViewBag.roomList = _context.Rooms.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Payment(int Id, float Due)
        {
            ViewBag.roomList = _context.Rooms.ToList();
            if (Id > 0)
            {
                BillViewModel guestBill = _context.Bill.FirstOrDefault(m => m.Id == Id);
                guestBill.TotalBill = Due;
                _context.Update(guestBill);
                _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }


            return View();
        }

       
        public IActionResult GetGuestByRoomId(int roomId)
        {
            
            var reserve = _context.Reserve.FirstOrDefault(m => m.RoomId == roomId && m.ConfirmChekout == false);
            if (reserve != null)
            {
                GuestsModel guest = _context.Guests.FirstOrDefault(m => m.Id == reserve.GuestId);
                BillViewModel guestBill = _context.Bill.FirstOrDefault(m => m.Id == reserve.GuestId);

                var newGuest = new
                {
                    Id = guest.Id,
                    Name = guest.Name,
                    Email = guest.Email,
                    TotalBill = guestBill.TotalBill
                };

                var jaon = JsonConvert.SerializeObject(newGuest);
                
                return Json(jaon);
            }
            else
            {
                var newGuest = new
                {
                    Id = 0,
                    Name = "Not found",
                    Email = "Not found",
                    TotalBill = 0
                };
                var jaon = JsonConvert.SerializeObject(newGuest);
                return Json(jaon);
            }

            

        }




        // GET: Order
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewBag.employeeList = _context.Employees.ToList();
            ViewBag.serviceList = _context.Services.ToList();
            ViewBag.roomList = _context.Rooms.ToList();


            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,EmployeeId,GuestId,ReservationCode,ServiceId,Price,Quantity,paid")] OrderModel orderModel)
        {            
            ViewBag.employeeList = _context.Employees.ToList();
            ViewBag.serviceList = _context.Services.ToList();
            ViewBag.roomList = _context.Rooms.ToList();

            int roomId = orderModel.GuestId;

            ReserveModel reserve = new ReserveModel();
            reserve = _context.Reserve.FirstOrDefault(m => m.RoomId == roomId  && m.ConfirmChekout == false);
            if (reserve != null)
            {
                orderModel.GuestId = reserve.GuestId;
                orderModel.ReservationCode = reserve.ReservationCode;
            }
            else
            {
                return NotFound();
            }

            ServiceModel service = new ServiceModel();
            service = _context.Services.SingleOrDefault(m => m.Id == orderModel.ServiceId);
            if (service != null)
            {
                orderModel.Price = service.Price;
            }


            if (ModelState.IsValid)
            {
                _context.Add(orderModel);

               
                BillViewModel user = _context.Bill.FirstOrDefault(m => m.GuestId == orderModel.GuestId);

                if (user == null)
                {
                    BillViewModel bill = new BillViewModel()
                    {
                        GuestId = orderModel.GuestId,
                        ReservationCode = orderModel.ReservationCode,
                        TotalBill = Convert.ToDouble(orderModel.Price)*orderModel.Quantity
                    };
                    _context.Bill.Add(bill);
                }
                else
                {
                    if(orderModel.paid==false)
                    {
                        user.TotalBill += (orderModel.Price * orderModel.Quantity);
                        _context.Bill.Update(user);
                    }                    
                }


                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderModel);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.Order.FindAsync(id);
            if (orderModel == null)
            {
                return NotFound();
            }
            return View(orderModel);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,EmployeeId,GuestId,ReservationCode,ServiceId,Price,Quantity,paid")] OrderModel orderModel)
        {
            if (id != orderModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderModelExists(orderModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderModel);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderModel = await _context.Order.FindAsync(id);
            _context.Order.Remove(orderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderModelExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
