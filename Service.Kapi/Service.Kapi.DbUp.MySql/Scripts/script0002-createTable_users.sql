USE `usersdb`;

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
ENGINE = InnoDB DEFAULT CHARSET=utf8;
