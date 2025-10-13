using CarMagazineISP_41.Data.Models;
using CarMagazineISP_411.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CarMagazineISP_41.Controllers
{
    public class CarsController : Controller
    {
        CarDbContext db;
        private IHostingEnvironment env;

        public CarsController(CarDbContext db, IHostingEnvironment hostingEnvironment)
        {
            this.db = db;
            env=hostingEnvironment;
        }


        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(Car car, IFormFile uploadedFile)
        {
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                try
                {
                    // Генерируем уникальное имя файла
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadedFile.FileName);

                    // Определяем путь к папке img
                    string imgFolder = Path.Combine(env.WebRootPath, "img");

                    // Создаем папку если не существует
                    if (!Directory.Exists(imgFolder))
                    {
                        Directory.CreateDirectory(imgFolder);
                    }

                    // Полный путь для сохранения файла
                    string fullPath = Path.Combine(imgFolder, fileName);

                    // Сохраняем файл
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        uploadedFile.CopyTo(fileStream);
                    }

                    // Сохраняем относительный путь в базу
                    car.Img = "/img/" + fileName;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ошибка при загрузке файла: " + ex.Message);
                    return View(car);
                }
            }
            else
            {
                ModelState.AddModelError("", "Пожалуйста, выберите файл изображения");
                return View(car);
            }

            db.Cars.Add(car);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EditCar(int carId)
        {
            var car = db.Cars.Find(carId);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public IActionResult EditCar(Car car, IFormFile uploadedFile)
        {
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                try
                {
                    // Генерируем уникальное имя файла
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadedFile.FileName);

                    // Определяем путь к папке img
                    string imgFolder = Path.Combine(env.WebRootPath, "img");

                    // Создаем папку если не существует
                    if (!Directory.Exists(imgFolder))
                    {
                        Directory.CreateDirectory(imgFolder);
                    }

                    // Полный путь для сохранения файла
                    string fullPath = Path.Combine(imgFolder, fileName);

                    // Сохраняем файл
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        uploadedFile.CopyTo(fileStream);
                    }

                    // Сохраняем относительный путь в базу
                    car.Img = "/img/" + fileName;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ошибка при загрузке файла: " + ex.Message);
                    return View(car);
                }
            }
            else
            {
                // Сохраняем существующее изображение если новое не загружено
                var existingCar = db.Cars.AsNoTracking().FirstOrDefault(c => c.CarId == car.CarId);
                if (existingCar != null)
                {
                    car.Img = existingCar.Img;
                }
            }

            db.Entry(car).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult DeleteCar(int carId)
        {
            var car = db.Cars.Find(carId);
            if (car != null)
            {
                // Удаляем файл изображения если он существует
                if (!string.IsNullOrEmpty(car.Img))
                {
                    string fullPath = Path.Combine(env.WebRootPath, car.Img.TrimStart('/'));
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }

                db.Cars.Remove(car);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        
       
    }
}
