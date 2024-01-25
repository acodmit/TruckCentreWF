-- Insert data into employee table with hashed passwords
INSERT INTO `TruckCentre`.`employee` (`username`, `password`, `isAdmin`, `status`, `firstName`, `lastName`, `theme`)
VALUES
  ('john_doe', 'ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f', 1, 1, 'John', 'Doe', 0), -- password123
  ('jane_smith', 'd758063f179e34e45ab99b93166b8baee514d60b0224747b8bb3fdf32c10d211', 0, 1, 'Jane', 'Smith', 0), -- securepass
  ('bob_johnson', 'da7655b5bf67039c3e76a99d8e6fb6969370bbc0fa440cae699cf1a3e2f1e0a1', 0, 1, 'Bob', 'Johnson', 0), -- bobpass
  ('susan_miller', '7481f07311ea646e2c12b34291202fe7ba8eb8aa650805a0ee72bc6c6550f93c', 0, 1, 'Susan', 'Miller', 0), -- millerpass
  ('mike_anderson', 'd6ab7a4ba46690f83961f28f7d537f4f8db309d75febd5656355561917b84cf8', 0, 1, 'Mike', 'Anderson', 0); -- mikepass

-- Insert data into client table
INSERT INTO `TruckCentre`.`client` (`idClient`, `name`, `email`, `address`)
VALUES
  (1, 'ABC Trucking', 'client1@example.com', '123 Main St'),
  (2, 'XYZ Logistics', 'client2@example.com', '456 Oak Ave'),
  (3, 'Smith Hauling', 'client3@example.com', '789 Elm Blvd'),
  (4, 'Miller Transport', 'client4@example.com', '101 Pine Lane'),
  (5, 'Anderson Trucking', 'client5@example.com', '222 Cedar Street'),
  (6, 'Johnson Freight', 'client6@example.com', '333 Oak Street'),
  (7, 'Doe Transports', 'client7@example.com', '444 Pine Blvd'),
  (8, 'Swift Shipping', 'client8@example.com', '555 Elm Street'),
  (9, 'Express Cargo', 'client9@example.com', '666 Oak Blvd'),
  (10, 'Thunder Trucking', 'client10@example.com', '777 Pine Ave');

-- Insert data into vehicle table
INSERT INTO `TruckCentre`.`vehicle` (`idVehicle`, `mileage`, `details`, `lastService`)
VALUES
  ('VIN12345678901234', '55023', 'Mercedes Benz Actros', '2022-01-15'),
  ('VIN23456789012345', '160370', 'Volvo FH16', '2022-02-20'),
  ('VIN34567890123456', '270405', 'Kenworth T680', '2022-03-25'),
  ('VIN45678901234567', '45401', 'DAF F22T1', '2022-04-10'),
  ('VIN56789012345678', '99852', 'Freightliner Cascadia', '2022-05-05'),
  ('VIN67890123456789', '352456', 'Peterbilt 579', '2022-06-15'),
  ('VIN78901234567890', '478024', 'International LT Series', '2022-07-20'),
  ('VIN89012345678901', '75300', 'Mack Anthem', '2022-08-25'),
  ('VIN90123456789012', '7022', 'Western Star 49X', '2022-09-30'),
  ('VIN01234567890123', '205021', 'Freightliner M2', '2022-10-10');

-- Insert data into service_ticket table
INSERT INTO `TruckCentre`.`service_ticket` (`idEmployee`, `idClient`, `details`)
VALUES
  (3, 1, 'Regular Maintenance'),
  (2, 2, 'Brake Inspection'),
  (3, 3, 'Oil Change'),
  (4, 2, 'Tire Rotation'),
  (4, 3, 'Diagnostic Check'),
  (2, 4, 'Annual Service'),
  (3, 5, 'Transmission Flush'),
  (4, 6, 'Engine Overhaul'),
  (2, 7, 'Brake Repair'),
  (2, 8, 'Cooling System Check');

-- Insert data into service table
INSERT INTO `TruckCentre`.`service` (`name`, `serviceFee`, `labour`)
VALUES
  ('Oil Change', 50.00, 20.00),
  ('Brake Inspection', 30.00, 15.00),
  ('Tire Rotation', 25.00, 10.00),
  ('Diagnostic Check', 40.00, 25.00),
  ('Engine Tune-up', 60.00, 30.00),
  ('Transmission Flush', 70.00, 35.00),
  ('Annual Service', 55.00, 22.00),
  ('Engine Overhaul', 120.00, 60.00),
  ('Brake Repair', 45.00, 18.00),
  ('Cooling System Check', 40.00, 20.00);

-- Insert data into part table
INSERT INTO `TruckCentre`.`part` (`name`, `unitPrice`)
VALUES
  ('Oil Filter (OEM)', 8.00),
  ('Brake Pads (Ceramic)', 30.00),
  ('Tire (Michelin)', 70.00),
  ('Spark Plugs (Iridium)', 12.00),
  ('Air Filter (High Flow)', 20.00),
  ('Transmission Fluid (Synthetic)', 25.00),
  ('Engine Oil (Full Synthetic)', 15.00),
  ('Brake Fluid (DOT 4)', 18.00),
  ('Radiator Coolant (Extended Life)', 22.00),
  ('Air Conditioning Refrigerant (R134a)', 30.00);

-- Insert data into service_invoice table
INSERT INTO `TruckCentre`.`service_invoice` (`idServiceTicket`, `total`)
VALUES
  (1, 75.00),
  (2, 45.00),
  (4, 60.00),
  (5, 65.00),
  (7, 95.00),
  (8, 180.00),
  (9, 63.00),
  (10, 60.00);

-- Insert data into item_part table
INSERT INTO `TruckCentre`.`item_part` (`serialNumber`, `idServiceTicket`, `name`, `unitPrice`, `quantity`)
VALUES
  (1, 1, 'Oil Filter (OEM)', 8.00, 2),
  (2, 2, 'Brake Pads (Ceramic)', 30.00, 1),
  (3, 4, 'Tire (Michelin)', 70.00, 4),
  (4, 4, 'Spark Plugs (Iridium)', 12.00, 6),
  (5, 5, 'Air Filter (High Flow)', 20.00, 3),
  (6, 8, 'Transmission Fluid (Synthetic)', 25.00, 1),
  (7, 8, 'Engine Oil (Full Synthetic)', 15.00, 3),
  (8, 8, 'Brake Fluid (DOT 4)', 18.00, 2),
  (9, 9, 'Radiator Coolant (Extended Life)', 22.00, 1),
  (10, 1, 'Air Conditioning Refrigerant (R134a)', 30.00, 1);

-- Insert data into item_service table
INSERT INTO `TruckCentre`.`item_service` (`idService`, `idServiceTicket`, `name`, `serviceFee`, `labour`, `labourAmount`)
VALUES
  (1, 1, 'Oil Change', 50.00, 20.00, 1),
  (2, 2, 'Brake Inspection', 30.00, 15.00, 1),
  (3, 3, 'Tire Rotation', 25.00, 10.00, 2),
  (4, 4, 'Diagnostic Check', 40.00, 25.00, 1),
  (5, 5, 'Engine Tune-up', 60.00, 30.00, 2),
  (6, 6, 'Transmission Flush', 70.00, 35.00, 1),
  (7, 7, 'Annual Service', 55.00, 22.00, 1),
  (8, 8, 'Engine Overhaul', 120.00, 60.00, 1),
  (9, 9, 'Brake Repair', 45.00, 18.00, 1),
  (10, 10, 'Cooling System Check', 40.00, 20.00, 1);

-- Insert data into service_ticket_vehicle table
INSERT INTO `TruckCentre`.`service_ticket_vehicle` (`idServiceTicket`, `idVehicle`)
VALUES
  (1, 'VIN12345678901234'),
  (2, 'VIN23456789012345'),
  (3, 'VIN34567890123456'),
  (4, 'VIN45678901234567'),
  (5, 'VIN56789012345678'),
  (6, 'VIN67890123456789'),
  (7, 'VIN78901234567890'),
  (8, 'VIN89012345678901'),
  (9, 'VIN90123456789012'),
  (10, 'VIN01234567890123');
