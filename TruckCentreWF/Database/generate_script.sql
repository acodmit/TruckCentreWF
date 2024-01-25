-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema TruckCentre
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema TruckCentre
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `TruckCentre` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
USE `TruckCentre` ;

-- -----------------------------------------------------
-- Table `TruckCentre`.`employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TruckCentre`.`employee` (
  `idEmployee` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(20) NOT NULL,
  `password` VARCHAR(64) NOT NULL,
  `isAdmin` TINYINT NOT NULL DEFAULT 0,
  `status` TINYINT NOT NULL,
  `firstName` VARCHAR(45) NULL,
  `lastName` VARCHAR(45) NULL,
  `theme` INT NOT NULL DEFAULT 0,
  PRIMARY KEY (`idEmployee`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TruckCentre`.`vehicle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TruckCentre`.`vehicle` (
  `idVehicle` VARCHAR(17) NOT NULL,
  `mileage` VARCHAR(10) NOT NULL,
  `details` VARCHAR(100) NULL,
  `lastService` DATETIME NULL,
  PRIMARY KEY (`idVehicle`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TruckCentre`.`client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TruckCentre`.`client` (
  `idClient` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(80) NULL DEFAULT 'Unknown',
  `email` VARCHAR(45) NOT NULL,
  `address` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idClient`),
  UNIQUE INDEX `idClient_UNIQUE` (`idClient` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TruckCentre`.`service_ticket`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TruckCentre`.`service_ticket` (
  `idServiceTicket` INT NOT NULL AUTO_INCREMENT,
  `idEmployee` INT NOT NULL,
  `idClient` INT NOT NULL,
  `entryDate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `details` VARCHAR(100) NOT NULL,
  `status` VARCHAR(20) NOT NULL DEFAULT 'Active',
  PRIMARY KEY (`idServiceTicket`),
  INDEX `fk_service_ticket_employee1_idx` (`idEmployee` ASC) VISIBLE,
  INDEX `fk_service_ticket_client1_idx` (`idClient` ASC) VISIBLE,
  CONSTRAINT `fk_service_ticket_employee1`
    FOREIGN KEY (`idEmployee`)
    REFERENCES `TruckCentre`.`employee` (`idEmployee`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_service_ticket_client1`
    FOREIGN KEY (`idClient`)
    REFERENCES `TruckCentre`.`client` (`idClient`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
ROW_FORMAT = COMPACT;


-- -----------------------------------------------------
-- Table `TruckCentre`.`service`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TruckCentre`.`service` (
  `idService` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(60) NOT NULL,
  `serviceFee` DECIMAL NOT NULL,
  `labour` DECIMAL NOT NULL,
  PRIMARY KEY (`idService`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TruckCentre`.`part`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TruckCentre`.`part` (
  `serialNumber` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(80) NOT NULL,
  `unitPrice` DECIMAL NOT NULL,
  PRIMARY KEY (`serialNumber`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TruckCentre`.`service_invoice`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TruckCentre`.`service_invoice` (
  `idServiceInvoice` INT NOT NULL AUTO_INCREMENT,
  `idServiceTicket` INT NOT NULL,
  `date` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `total` DECIMAL NULL DEFAULT 0,
  PRIMARY KEY (`idServiceInvoice`),
  INDEX `fk_service_invoice_service_ticket1_idx` (`idServiceTicket` ASC) VISIBLE,
  CONSTRAINT `fk_service_invoice_service_ticket1`
    FOREIGN KEY (`idServiceTicket`)
    REFERENCES `TruckCentre`.`service_ticket` (`idServiceTicket`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TruckCentre`.`item_part`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TruckCentre`.`item_part` (
  `serialNumber` INT NOT NULL,
  `idServiceTicket` INT NOT NULL,
  `name` VARCHAR(80) NULL,
  `unitPrice` DECIMAL NULL,
  `quantity` INT NULL,
  `itemPrice` DECIMAL GENERATED ALWAYS AS (unitPrice * quantity) VIRTUAL,
  PRIMARY KEY (`serialNumber`, `idServiceTicket`),
  INDEX `fk_item_part_part1_idx` (`serialNumber` ASC) VISIBLE,
  INDEX `fk_item_part_service_ticket1_idx` (`idServiceTicket` ASC) VISIBLE,
  CONSTRAINT `fk_item_part_part1`
    FOREIGN KEY (`serialNumber`)
    REFERENCES `TruckCentre`.`part` (`serialNumber`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_item_part_service_ticket1`
    FOREIGN KEY (`idServiceTicket`)
    REFERENCES `TruckCentre`.`service_ticket` (`idServiceTicket`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TruckCentre`.`item_service`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TruckCentre`.`item_service` (
  `idService` INT NOT NULL,
  `idServiceTicket` INT NOT NULL,
  `name` VARCHAR(100) NULL,
  `serviceFee` DECIMAL NULL,
  `labour` DECIMAL NULL,
  `labourAmount` INT NULL,
  `itemPrice` DECIMAL GENERATED ALWAYS AS (serviceFee + (labour * labourAmount)) VIRTUAL,
  PRIMARY KEY (`idService`, `idServiceTicket`),
  INDEX `fk_item_service_service1_idx` (`idService` ASC) VISIBLE,
  INDEX `fk_item_service_service_ticket1_idx` (`idServiceTicket` ASC) VISIBLE,
  CONSTRAINT `fk_item_service_service1`
    FOREIGN KEY (`idService`)
    REFERENCES `TruckCentre`.`service` (`idService`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_item_service_service_ticket1`
    FOREIGN KEY (`idServiceTicket`)
    REFERENCES `TruckCentre`.`service_ticket` (`idServiceTicket`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TruckCentre`.`service_ticket_vehicle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TruckCentre`.`service_ticket_vehicle` (
  `idServiceTicket` INT NOT NULL,
  `idVehicle` VARCHAR(17) NOT NULL,
  PRIMARY KEY (`idServiceTicket`, `idVehicle`),
  INDEX `fk_service_ticket_vehicle_vehicle1_idx` (`idVehicle` ASC) VISIBLE,
  CONSTRAINT `fk_service_ticket_vehicle_service_ticket1`
    FOREIGN KEY (`idServiceTicket`)
    REFERENCES `TruckCentre`.`service_ticket` (`idServiceTicket`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_service_ticket_vehicle_vehicle1`
    FOREIGN KEY (`idVehicle`)
    REFERENCES `TruckCentre`.`vehicle` (`idVehicle`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
