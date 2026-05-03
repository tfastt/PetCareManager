using PetCareManager.DataAccess;
using PetCareManager.Model;

Console.WriteLine("Testing database...");

UserService service = new UserService();

try
{
    var users = service.GetAllUsers();

    Console.WriteLine("Connected SUCCESS!");
    Console.WriteLine("Total users: " + users.Count);

    foreach (var u in users)
    {
        Console.WriteLine($"{u.UserID} - {u.UserName}");
    }
    Console.WriteLine("\n=== TEST GET USER BY ID ===");
 
    var user = service.GetUserByID(1);

    if (user != null)
    {
        Console.WriteLine($"Found: {user.UserID} - {user.UserName} - {user.Email}");
    }
    else
    {
        Console.WriteLine("User not found.");
    }
    /*
         Console.WriteLine("\n=== TEST ADD USER ===");

        service.AddUser(new PetCareManager.Model.User
        {
            UserName = "Test User CSharp",
            Phone = "0999999999",
            Address = "HCM",
            Email = $"test_{DateTime.Now.Ticks}@example.com",
            PasswordHash = "hash_test",
            Role = "Owner",
            Note = "Created from C# test"
        });
        

    Console.WriteLine("Add user completed.");
    Console.WriteLine("\n=== AFTER ADD ===");

    var usersAfterAdd = service.GetAllUsers();

    foreach (var u in usersAfterAdd)
    {
        Console.WriteLine($"{u.UserID} - {u.UserName}");
    }
    
    Console.WriteLine("\n=== TEST UPDATE USER ===");

    service.UpdateUser(new PetCareManager.Model.User
    {
        UserID = 11,
        UserName = "Test User Updated",
        Phone = "0888888888",
        Address = "Da Nang",
        Email = $"updated_{DateTime.Now.Ticks}@example.com",
        PasswordHash = "hash_updated",
        Role = "Owner",
        Note = "Updated from C# test"
    });

    var updatedUser = service.GetUserByID(11);

    Console.WriteLine($"After update: {updatedUser.UserID} - {updatedUser.UserName} - {updatedUser.Email}");
    */
    // Console.WriteLine("\n=== TEST DELETE USER ===");

    // // dùng ID bạn vừa test 
    // service.DeleteUser(11);

    // // kiểm tra lại
    // var afterDelete = service.GetAllUsers();

    // Console.WriteLine("=== AFTER DELETE ===");
    // foreach (var u in afterDelete)
    // {
    //     Console.WriteLine($"{u.UserID} - {u.UserName}");
    // }
    Console.WriteLine("\n=== TEST PET: GET ALL ===");

    PetService petService = new PetService();

    var pets = petService.GetAllPets();

    foreach (var p in pets)
    {
        Console.WriteLine($"{p.PetID} - {p.PetName} - {p.Species} - Owner/UserID: {p.UserID}");
    }

    Console.WriteLine("\n=== TEST PET: GET BY ID ===");

    var pet = petService.GetPetByID(1);

    if (pet != null)
    {
        Console.WriteLine($"Found: {pet.PetID} - {pet.PetName} - {pet.Species} - {pet.Breed}");
    }
    else
    {
        Console.WriteLine("Pet not found.");
    }
    /*
    Console.WriteLine("\n=== TEST PET: ADD ===");

    petService.AddPet(new Pet
    {
        PetName = "Buddy CSharp",
        Species = "Dog",
        Breed = "Shiba Inu",
        DateOfBirth = new DateTime(2023, 3, 15),
        Weight = 9.5,
        HealthStatus = "Healthy",
        UserID = 1,
        Gender = "Male",
        Note = "Created from C# test"
    });
    

    Console.WriteLine("Add pet completed.");
*/
    // Console.WriteLine("\n=== PET AFTER ADD ===");

    // var petsAfterAdd = petService.GetAllPets();

    // foreach (var p in petsAfterAdd)
    // {
    //     Console.WriteLine($"{p.PetID} - {p.PetName} - {p.Species} - Owner/UserID: {p.UserID}");
    // }

    // Console.WriteLine("\n=== TEST PET: UPDATE ===");

    // petService.UpdatePet(new Pet
    // {
    //     PetID = 10,
    //     PetName = "Buddy Updated",
    //     Species = "Dog",
    //     Breed = "Shiba Inu",
    //     DateOfBirth = new DateTime(2023, 3, 15),
    //     Weight = 10.2,
    //     HealthStatus = "Very Healthy",
    //     UserID = 1,
    //     Gender = "Male",
    //     Note = "Updated from C#"
    // });

    // var updatedPet = petService.GetPetByID(10);

    // if (updatedPet != null)
    // {
    //     Console.WriteLine($"After update: {updatedPet.PetID} - {updatedPet.PetName} - {updatedPet.HealthStatus}");
    // }
    // else
    // {
    //     Console.WriteLine("Pet not found after update.");
    // }

    // Console.WriteLine("\n=== TEST PET: DELETE ===");


    // petService.DeletePet(10);

    // Console.WriteLine("Delete pet completed.");

    // Console.WriteLine("\n=== PET AFTER DELETE ===");

    // var petsAfterDelete = petService.GetAllPets();

    // foreach (var p in petsAfterDelete)
    // {
    //     Console.WriteLine($"{p.PetID} - {p.PetName} - {p.Species} - Owner/UserID: {p.UserID}");
    // }
    
    Console.WriteLine("\n=== TEST VACCINE: GET ALL ===");

    VaccineService vaccineService = new VaccineService();

    var vaccines = vaccineService.GetAllVaccines();

    foreach (var v in vaccines)
    {
        Console.WriteLine($"{v.VaccineID} - {v.VaccineName} - {v.ForSpecies}");
    }

    Console.WriteLine("\n=== TEST VACCINE: GET BY ID ===");

    var vaccine = vaccineService.GetVaccineByID(1);

    if (vaccine != null)
    {
        Console.WriteLine($"Found: {vaccine.VaccineID} - {vaccine.VaccineName} - {vaccine.PreventDisease}");
    }
    else
    {
        Console.WriteLine("Vaccine not found.");
    }
    // Console.WriteLine("\n=== TEST VACCINE: ADD ===");

    //  vaccineService.AddVaccine(new Vaccine
    //  {
    //      VaccineName = "Parvo Test Vaccine",
    //      ForSpecies = "Dog",
    //      PreventDisease = "Prevents parvovirus disease",
    //      RecommendedIntervalMonths = 12,
    //     Note = "Created from C# test"
    // });

    // Console.WriteLine("Add vaccine completed.");

    // Console.WriteLine("\n=== VACCINE AFTER ADD ===");

    // var vaccinesAfterAdd = vaccineService.GetAllVaccines();

    // foreach (var v in vaccinesAfterAdd)
    // {
    //     Console.WriteLine($"{v.VaccineID} - {v.VaccineName} - {v.ForSpecies}");
    // }

    Console.WriteLine("\n=== TEST SCHEDULE: GET ALL ===");

    var scheduleService = new VaccinationScheduleService();

    var schedules = scheduleService.GetAllSchedules();

    foreach (var s in schedules)
    {
        Console.WriteLine($"ScheduleID: {s.ScheduleID} - PetID: {s.PetID} - VaccineID: {s.VaccineID} - Next: {s.NextVaccinationDate}");
    }

    Console.WriteLine("\n=== TEST SCHEDULE: GET BY ID ===");

    var schedule = scheduleService.GetScheduleByID(1);

    if (schedule != null)
    {
        Console.WriteLine($"Found: {schedule.ScheduleID} - PetID: {schedule.PetID}");
    }
    else
    {
        Console.WriteLine("Schedule not found.");
    }

    // Console.WriteLine("\n=== TEST SCHEDULE: UPDATE ===");

    // scheduleService.UpdateSchedule(new VaccinationSchedule
    // {
    //     ScheduleID = 2, 
    //     VaccinationDate = new DateTime(2026, 6, 1),
    //     Status = "Scheduled",
    //     Note = "Updated schedule from C# test"
    // });

    // var updatedSchedule = scheduleService.GetScheduleByID(2);

    // if (updatedSchedule != null)
    // {
    //     Console.WriteLine($"After update: {updatedSchedule.ScheduleID} - Date: {updatedSchedule.VaccinationDate} - Next: {updatedSchedule.NextVaccinationDate} - Status: {updatedSchedule.Status}");
    // }
    // else
    // {
    //     Console.WriteLine("Schedule not found after update.");
    // }

    // Console.WriteLine("\n=== TEST SCHEDULE: COMPLETE ===");

    // scheduleService.CompleteSchedule(
    //     2,
    //     new DateTime(2026, 6, 10),
    //     "Completed schedule from C# test"
    // );

    // var completedSchedule = scheduleService.GetScheduleByID(2);

    // if (completedSchedule != null)
    // {
    //     Console.WriteLine($"After complete: {completedSchedule.ScheduleID} - Date: {completedSchedule.VaccinationDate} - Status: {completedSchedule.Status} - Note: {completedSchedule.Note}");
    // }
    // else
    // {
    //     Console.WriteLine("Schedule not found after complete.");
    // }

    Console.WriteLine("\n=== TEST SCHEDULE: UPCOMING ===");

    var upcomingSchedules = scheduleService.GetUpcomingVaccinations();

    foreach (var s in upcomingSchedules)
    {
        Console.WriteLine($"Upcoming: {s.ScheduleID} - PetID:{s.PetID} - VaccineID:{s.VaccineID} - Next:{s.NextVaccinationDate} - Status:{s.Status}");
    }

    Console.WriteLine("\n=== TEST NOTIFICATION ===");

    var notificationService = new NotificationService();

    var notifications = notificationService.GetAllNotifications();

    foreach (var n in notifications)
    {
        Console.WriteLine($"{n.NotificationID} - User:{n.UserID} - {n.Title} - Read:{n.IsRead}");
    }

    Console.WriteLine("\n=== TEST NOTIFICATION: GET BY USER ID ===");

    var userNotifications = notificationService.GetNotificationsByUserID(1);

    foreach (var n in userNotifications)
    {
        Console.WriteLine($"{n.NotificationID} - User:{n.UserID} - {n.Title} - Read:{n.IsRead}");
    }

    // Console.WriteLine("\n=== TEST NOTIFICATION: MARK AS READ ===");

    // notificationService.MarkAsRead(1);

    // var afterRead = notificationService.GetAllNotifications();

    // foreach (var n in afterRead)
    // {
    //     Console.WriteLine($"{n.NotificationID} - Read:{n.IsRead}");
    // }

    // Console.WriteLine("\n=== TEST NOTIFICATION: DELETE ===");

    // notificationService.DeleteNotification(3); 

    // var afterDeleteNoti = notificationService.GetAllNotifications();

    // foreach (var n in afterDeleteNoti)
    // {
    //     Console.WriteLine($"{n.NotificationID} - User:{n.UserID} - Read:{n.IsRead}");
    // }

}
catch (Exception ex)
{
    Console.WriteLine("ERROR:");
    Console.WriteLine(ex.Message);
}