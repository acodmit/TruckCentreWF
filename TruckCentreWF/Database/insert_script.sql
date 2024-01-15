-- Insert data into employee table with hashed passwords
INSERT INTO `TruckCentre`.`employee` (`username`, `password`, `isAdmin`, `status`, `firstName`, `lastName`, `theme`)
VALUES
  ('john_doe', 'ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f', 1, 1, 'John', 'Doe', 0), -- password123
  ('jane_smith', 'd758063f179e34e45ab99b93166b8baee514d60b0224747b8bb3fdf32c10d211', 0, 1, 'Jane', 'Smith', 0), -- securepass
  ('bob_johnson', 'da7655b5bf67039c3e76a99d8e6fb6969370bbc0fa440cae699cf1a3e2f1e0a1', 0, 1, 'Bob', 'Johnson', 0), -- bobpass
  ('susan_miller', '7481f07311ea646e2c12b34291202fe7ba8eb8aa650805a0ee72bc6c6550f93c', 0, 1, 'Susan', 'Miller', 0), -- millerpass
  ('mike_anderson', 'd6ab7a4ba46690f83961f28f7d537f4f8db309d75febd5656355561917b84cf8', 0, 1, 'Mike', 'Anderson', 0); -- mikepass

-- Insert data into client table
INSERT INTO `TruckCentre`.`client` (`email`, `address`)
VALUES
  ('client1@example.com', '123 Main St'),
  ('client2@example.com', '456 Oak Ave'),
  ('client3@example.com', '789 Elm Blvd'),
  ('client4@example.com', '101 Pine Lane'),
  ('client5@example.com', '222 Cedar Street');

-- Insert data into vehicle table
INSERT INTO `TruckCentre`.`vehicle` (`idVehicle`, `mileage`, `details`, `lastService`)
VALUES
  ('VIN12345678901234', '50000', "Mercedes Benz Actros", '2022-01-15'),
  ('VIN23456789012345', '60000', NULL, '2022-02-20'),
  ('VIN34567890123456', '70000', NULL, '2022-03-25'),
  ('VIN45678901234567', '45000', "DAF F22T1", '2022-04-10'),
  ('VIN56789012345678', '80000', NULL, '2022-05-05');

-- Insert data into service_ticket table
INSERT INTO `TruckCentre`.`service_ticket` (`idEmployee`,`idclient`,`details`)
VALUES
  (1, 1, 'Regular Maintenance'),
  (2, 2, 'Brake Inspection'),
  (3, 3,'Oil Change'),
  (1, 2,'Tire Rotation'),
  (4, 3,'Diagnostic Check');

-- Insert data into service table
INSERT INTO `TruckCentre`.`service` (`name`, `serviceFee`, `labour`)
VALUES
  ('Oil Change', 50.00, 20.00),
  ('Brake Inspection', 30.00, 15.00),
  ('Tire Rotation', 25.00, 10.00),
  ('Diagnostic Check', 40.00, 25.00),
  ('Engine Tune-up', 60.00, 30.00);

-- Insert data into part table
INSERT INTO `TruckCentre`.`part` (`name`, `unitPrice`)
VALUES
  ('Oil Filter', 5.00),
  ('Brake Pads', 20.00),
  ('Tire', 50.00),
  ('Spark Plugs', 8.00),
  ('Air Filter', 12.00);

-- Insert data into service_invoice table
INSERT INTO `TruckCentre`.`service_invoice` (`idServiceTicket`, `total`)
VALUES
  (1, 75.00),
  (2, 45.00),
  (3, 35.00),
  (4, 60.00),
  (5, 65.00);

-- Insert data into item_part table
INSERT INTO `TruckCentre`.`item_part` (`serialNumber`, `idServiceTicket`, `name`, `unitPrice`, `quantity`)
VALUES
  (1, 1, 'Oil Filter', 5.00, 2),
  (2, 2, 'Brake Pads', 20.00, 1),
  (3, 3, 'Tire', 50.00, 4),
  (4, 4, 'Spark Plugs', 8.00, 6),
  (5, 5, 'Air Filter', 12.00, 3);

-- Insert data into item_service table
INSERT INTO `TruckCentre`.`item_service` (`idService`, `idServiceTicket`, `name`, `serviceFee`, `labour`, `labourAmount`)
VALUES
  (1, 1, 'Oil Change', 50.00, 20.00, 1),
  (2, 2, 'Brake Inspection', 30.00, 15.00, 1),
  (3, 3, 'Tire Rotation', 25.00, 10.00, 2),
  (4, 4, 'Diagnostic Check', 40.00, 25.00, 1),
  (5, 5, 'Engine Tune-up', 60.00, 30.00, 2);

-- Insert data into service_ticket_vehicle table
INSERT INTO `TruckCentre`.`service_ticket_vehicle` (`idServiceTicket`, `idVehicle`)
VALUES
  (1, 'VIN12345678901234'),
  (2, 'VIN23456789012345'),
  (3, 'VIN34567890123456'),
  (4, 'VIN45678901234567'),
  (5, 'VIN56789012345678');
