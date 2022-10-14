-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 14, 2022 at 02:40 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_revsystem`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `getBarangay` ()   BEGIN
  SELECT * FROM tbl_barangay;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getCustomer` ()   BEGIN 
SELECT id, firstName,middleName, lastName, houseNumber, g_gender, bgy_name 
FROM ((tbl_members INNER JOIN tbl_gender on tbl_gender.g_id = tbl_members.g_id)
INNER JOIN tbl_barangay on tbl_barangay.bgy_id = tbl_members.b_id) WHERE isDelete = 0 ORDER BY id ASC;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_account`
--

CREATE TABLE `tbl_account` (
  `a_id` int(15) NOT NULL,
  `a_user` varchar(50) NOT NULL,
  `a_password` varchar(50) NOT NULL,
  `userHash` varchar(300) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_account`
--

INSERT INTO `tbl_account` (`a_id`, `a_user`, `a_password`, `userHash`) VALUES
(1, 'admin', 'admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_barangay`
--

CREATE TABLE `tbl_barangay` (
  `bgy_id` int(10) NOT NULL,
  `bgy_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_barangay`
--

INSERT INTO `tbl_barangay` (`bgy_id`, `bgy_name`) VALUES
(1, 'Arkong Bato'),
(2, 'Bagbaguin'),
(3, 'Balangkas'),
(4, 'Bignay'),
(5, 'Bisig'),
(6, 'Canumay East'),
(7, 'Canumay West'),
(8, 'Coloong'),
(9, 'Dalandanan'),
(10, 'Gen. T De Leon'),
(11, 'Isla'),
(12, 'Karuhatan'),
(13, 'Lawang Bato '),
(14, 'Lingunan'),
(15, 'Mabolo'),
(16, 'Malanday'),
(17, 'Malinta'),
(18, 'Mapulang Lupa'),
(19, 'Marulas'),
(20, 'Maysan'),
(21, 'Palasan'),
(22, 'Parada'),
(23, 'Pariancillo Villa'),
(24, 'Paso de Blas'),
(25, 'Pasolo'),
(26, 'Poblacion'),
(27, 'Polo'),
(28, 'Punturin'),
(29, 'Rincon'),
(30, 'Tagalag'),
(31, 'Ugong'),
(32, 'Veinte Reales'),
(33, 'Wawang Pulo');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_gender`
--

CREATE TABLE `tbl_gender` (
  `g_id` int(1) NOT NULL,
  `g_gender` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_gender`
--

INSERT INTO `tbl_gender` (`g_id`, `g_gender`) VALUES
(1, 'Male'),
(2, 'Female');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_members`
--

CREATE TABLE `tbl_members` (
  `id` int(10) NOT NULL,
  `firstName` varchar(50) NOT NULL,
  `middleName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  `houseNumber` varchar(50) NOT NULL,
  `g_id` int(10) NOT NULL,
  `b_id` int(10) NOT NULL,
  `isDelete` smallint(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_members`
--

INSERT INTO `tbl_members` (`id`, `firstName`, `middleName`, `lastName`, `houseNumber`, `g_id`, `b_id`, `isDelete`) VALUES
(3, '', '', '', '', 1, 1, 0),
(4, 'as', 'as', 'as', 'as', 1, 8, 1),
(5, 'fafa', 'fa', 'fa', 'fa', 2, 2, 1),
(7, 'fafaf', 'afafa', 'fafa', 'fafa', 1, 1, 0),
(13, 'mark', 'mark', 'mark', 'mark', 1, 14, 1),
(14, 'as', 'as', 'as', 'as', 2, 1, 1),
(15, 'sad', 'asd', 'asda', 'sdasd', 1, 1, 1),
(16, 'asdasd', 'asdasd', 'asdasd', 'asdasd', 1, 1, 1),
(17, 'Mark', 'Tacud', 'Arcedas', '4031', 1, 10, 1),
(18, 'done', 'done', 'done', 'done', 1, 9, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_account`
--
ALTER TABLE `tbl_account`
  ADD PRIMARY KEY (`a_id`);

--
-- Indexes for table `tbl_barangay`
--
ALTER TABLE `tbl_barangay`
  ADD PRIMARY KEY (`bgy_id`);

--
-- Indexes for table `tbl_gender`
--
ALTER TABLE `tbl_gender`
  ADD PRIMARY KEY (`g_id`);

--
-- Indexes for table `tbl_members`
--
ALTER TABLE `tbl_members`
  ADD PRIMARY KEY (`id`),
  ADD KEY `g_id` (`g_id`),
  ADD KEY `b_id` (`b_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_account`
--
ALTER TABLE `tbl_account`
  MODIFY `a_id` int(15) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tbl_barangay`
--
ALTER TABLE `tbl_barangay`
  MODIFY `bgy_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT for table `tbl_gender`
--
ALTER TABLE `tbl_gender`
  MODIFY `g_id` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbl_members`
--
ALTER TABLE `tbl_members`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tbl_members`
--
ALTER TABLE `tbl_members`
  ADD CONSTRAINT `tbl_members_ibfk_1` FOREIGN KEY (`g_id`) REFERENCES `tbl_gender` (`g_id`),
  ADD CONSTRAINT `tbl_members_ibfk_2` FOREIGN KEY (`b_id`) REFERENCES `tbl_barangay` (`bgy_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
