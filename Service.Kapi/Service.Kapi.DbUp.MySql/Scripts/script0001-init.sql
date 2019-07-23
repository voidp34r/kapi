CREATE DATABASE IF NOT EXISTS `maindb` DEFAULT CHARACTER SET utf8;
USE `maindb`;
-- MySQL Script generated by MySQL Workbench
-- Sat Jul 20 15:18:21 2019
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering


-- -----------------------------------------------------
-- Schema maindb
-- -----------------------------------------------------
-- ENGINE=InnoDB DEFAULT CHARSET=utf8
DROP SCHEMA IF EXISTS `maindb` ;

-- -----------------------------------------------------
-- Schema maindb
--
-- ENGINE=InnoDB DEFAULT CHARSET=utf8
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `maindb` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin ;
SHOW WARNINGS;
-- -----------------------------------------------------
-- Schema maindb
-- -----------------------------------------------------
-- ENGINE=InnoDB DEFAULT CHARSET=utf8
DROP SCHEMA IF EXISTS `maindb` ;

-- -----------------------------------------------------
-- Schema maindb
--
-- ENGINE=InnoDB DEFAULT CHARSET=utf8
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `maindb` DEFAULT CHARACTER SET utf8 ;
SHOW WARNINGS;
USE `maindb` ;

-- -----------------------------------------------------
-- Table `homes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `homes` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `homes` (
  `id` VARCHAR(36) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `block` VARCHAR(45) NOT NULL,
  `number` VARCHAR(9) NOT NULL,
  `hometype` TINYINT(1) NOT NULL,
  `lives` JSON NULL,
  `createdon` DATETIME NULL,
  `modifiedon` DATETIME NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `homes_has_users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `homes_has_users` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `homes_has_users` (
  `homes_id` VARCHAR(36) NOT NULL,
  `users_id` VARCHAR(36) NOT NULL,
  PRIMARY KEY (`homes_id`, `users_id`))
ENGINE = InnoDB;

SHOW WARNINGS;
USE `maindb` ;

-- -----------------------------------------------------
-- Table `users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `users` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `users` (
  `id` VARCHAR(36) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `usertype` TINYINT(1) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `cpf` INT(11) NOT NULL,
  `birth` DATETIME NOT NULL,
  `telephone` VARCHAR(12) NULL,
  `deleted` TINYINT NULL,
  `createdon` DATETIME NULL,
  `modifiedon` DATETIME NULL,
  `deletedon` DATETIME NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

SHOW WARNINGS;

-- SET SQL_MODE=@OLD_SQL_MODE;
-- SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
-- SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
