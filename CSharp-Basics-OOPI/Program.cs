// ---- C# I (Dor Ben Dor) ----
// Ori Shacham-Barr
// ----------------------------

Car car = new Car(10, 20, 160);

car.Start();

Console.WriteLine($"Distance: {car.TotalDistanceCovered}");
Console.WriteLine($"Speed: {car.CurrentSpeed}\r\n");

car.Accelerate(3);
Console.WriteLine($"Distance: {car.TotalDistanceCovered}");
Console.WriteLine($"Speed: {car.CurrentSpeed}\r\n");

car.Accelerate(-3);
Console.WriteLine($"Distance: {car.TotalDistanceCovered}");
Console.WriteLine($"Speed: {car.CurrentSpeed}\r\n");

car.Cruise(3);
Console.WriteLine($"Distance: {car.TotalDistanceCovered}");
Console.WriteLine($"Speed: {car.CurrentSpeed}\r\n");

car.Deccelerate(3);
Console.WriteLine($"Distance: {car.TotalDistanceCovered}");
Console.WriteLine($"Speed: {car.CurrentSpeed}\r\n");

car.Deccelerate(4);
Console.WriteLine($"Distance: {car.TotalDistanceCovered}");
Console.WriteLine($"Speed: {car.CurrentSpeed}\r\n");

car.TurnOff();