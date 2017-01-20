-- phpMyAdmin SQL Dump
-- version 4.5.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jan 20, 2017 at 10:48 AM
-- Server version: 5.7.11
-- PHP Version: 5.6.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `owl-learn`
--

-- --------------------------------------------------------

--
-- Table structure for table `antwoorden`
--

CREATE TABLE `antwoorden` (
  `AntwoordID` int(11) NOT NULL,
  `VraagID` int(11) NOT NULL,
  `Antwoord` varchar(20) NOT NULL,
  `Juist_onjuist` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `antwoorden`
--

INSERT INTO `antwoorden` (`AntwoordID`, `VraagID`, `Antwoord`, `Juist_onjuist`) VALUES
(1, 6, '6', '2'),
(2, 6, '9', '2'),
(3, 6, '4', '1'),
(4, 6, '2', '2'),
(5, 7, '8', '1'),
(6, 7, '3', '2'),
(7, 7, '7', '2'),
(8, 7, '5', '2'),
(9, 8, '2', '2'),
(10, 8, '8', '2'),
(11, 8, '1', '1'),
(12, 8, '3', '2'),
(13, 9, '7', '1'),
(14, 9, '4', '2'),
(15, 9, '3', '2'),
(16, 9, '6', '2'),
(17, 10, '8', '2'),
(18, 10, '4', '2'),
(19, 10, '2', '2'),
(20, 10, '5', '1'),
(41, 11, 'Monkey', '2'),
(42, 11, 'Horse', '1'),
(43, 11, 'Tiger', '2'),
(44, 11, 'Bear', '2'),
(45, 12, 'Panda', '2'),
(46, 12, 'Dog', '2'),
(47, 12, 'Pig', '1'),
(48, 12, 'Cat', '2'),
(49, 13, 'Moo!', '1'),
(50, 13, 'Quack!', '2'),
(51, 13, 'Woof!', '2'),
(52, 13, 'Chirp!', '2'),
(53, 14, 'Twee', '2'),
(54, 14, 'Vier', '1'),
(55, 14, 'Een', '2'),
(56, 14, 'Drie', '2'),
(57, 15, 'Meow!', '2'),
(58, 15, 'Moo!', '2'),
(59, 15, 'Oink!', '2'),
(60, 15, 'Tok tok tok!', '1'),
(61, 16, '10', '2'),
(62, 16, '8', '2'),
(63, 16, '4', '1'),
(64, 16, '20', '2'),
(65, 17, '16', '1'),
(66, 17, '24', '2'),
(67, 17, '4', '2'),
(68, 17, '12', '2'),
(69, 18, '5', '2'),
(70, 18, '20', '1'),
(71, 18, '15', '2'),
(72, 18, '28', '2'),
(73, 19, '2', '2'),
(74, 19, '16', '2'),
(75, 19, '20', '2'),
(76, 19, '8', '1'),
(77, 20, '10', '1'),
(78, 20, '20', '2'),
(79, 20, '50', '2'),
(80, 20, '15', '2'),
(81, 21, '9', '2'),
(82, 21, '6', '2'),
(83, 21, '21', '2'),
(84, 21, '3', '1'),
(85, 22, '21', '1'),
(86, 22, '14', '2'),
(87, 22, '30', '2'),
(88, 22, '3', '2'),
(89, 23, '10', '2'),
(90, 23, '35', '2'),
(91, 23, '15', '1'),
(92, 23, '16', '2'),
(93, 24, '27', '1'),
(94, 24, '15', '2'),
(95, 24, '20', '2'),
(96, 24, '60', '2'),
(97, 25, '16', '2'),
(98, 25, '9', '2'),
(99, 25, '24', '2'),
(100, 25, '12', '1'),
(101, 26, '25', '2'),
(102, 26, '4', '2'),
(103, 26, '10', '2'),
(104, 26, '40', '1'),
(105, 27, '15', '2'),
(106, 27, '20', '1'),
(107, 27, '10', '2'),
(108, 27, '16', '2'),
(109, 28, '8', '1'),
(110, 28, '16', '2'),
(111, 28, '20', '2'),
(112, 28, '2', '2'),
(113, 29, '32', '1'),
(114, 29, '24', '2'),
(115, 29, '28', '2'),
(116, 29, '34', '2'),
(117, 30, '12', '2'),
(118, 30, '8', '2'),
(119, 30, '16', '1'),
(120, 30, '20', '2'),
(121, 31, '40', '2'),
(122, 31, '50', '2'),
(123, 31, '45', '1'),
(124, 31, '35', '2'),
(125, 32, '15', '2'),
(126, 32, '20', '2'),
(127, 32, '2', '2'),
(128, 32, '10', '1'),
(129, 33, '40', '2'),
(130, 33, '20', '1'),
(131, 33, '10', '2'),
(132, 33, '25', '2'),
(133, 34, '10', '2'),
(134, 34, '60', '2'),
(135, 34, '50', '1'),
(136, 34, '25', '2'),
(137, 35, '30', '1'),
(138, 35, '40', '2'),
(139, 35, '15', '2'),
(140, 35, '55', '2'),
(141, 36, '30', '2'),
(142, 36, '40', '2'),
(143, 36, '80', '1'),
(144, 36, '25', '2'),
(145, 37, '30', '1'),
(146, 37, '39', '2'),
(147, 37, '60', '2'),
(148, 37, '10', '2'),
(149, 38, '70', '2'),
(150, 38, '25', '2'),
(151, 38, '100', '2'),
(152, 38, '50', '1'),
(153, 39, '50', '2'),
(154, 39, '100', '1'),
(155, 39, '110', '2'),
(156, 39, '40', '2'),
(157, 40, '35', '2'),
(158, 40, '70', '1'),
(159, 40, '80', '2'),
(160, 40, '35', '2'),
(161, 41, 'Kaneelstok', '2'),
(162, 41, 'Zuurstok', '1'),
(163, 41, 'Aardappel', '2'),
(164, 41, 'Chocolade', '2'),
(165, 42, 'Kip', '2'),
(166, 42, 'Rund', '2'),
(167, 42, 'Hamburger', '2'),
(168, 42, 'Kalkoen', '1'),
(169, 43, 'Wijn', '1'),
(170, 43, 'Bier', '2'),
(171, 43, 'Ranja', '2'),
(172, 43, 'Cola', '2'),
(173, 44, 'Biefstuk', '1'),
(174, 44, 'Frietjes', '2'),
(175, 44, 'Spinazie', '2'),
(176, 44, 'Brocoli', '2'),
(177, 45, 'Biefstuk', '2'),
(178, 45, 'Aardappel', '2'),
(179, 45, 'Bloemkool', '2'),
(180, 45, 'Ijstaart', '1'),
(181, 46, 'Bike', '2'),
(182, 46, 'Ring', '2'),
(183, 46, 'Necklace', '1'),
(184, 46, 'Bracelet', '2'),
(185, 47, 'Gitaar', '1'),
(186, 47, 'Piano', '2'),
(187, 47, 'Basketbal', '2'),
(188, 47, 'Ring', '2'),
(189, 48, 'Drumset', '2'),
(190, 48, 'Oordopjes', '2'),
(191, 48, 'Broek', '2'),
(192, 48, 'Sokken', '1'),
(193, 49, 'Ring', '2'),
(194, 49, 'Bracelet', '1'),
(195, 49, 'T-Shirt', '2'),
(196, 49, 'Shoes', '2'),
(197, 50, '35', '2'),
(198, 50, '40', '2'),
(199, 50, '70', '1'),
(200, 50, '75', '2'),
(205, 52, '28', '1'),
(206, 52, '12', '2'),
(207, 52, '32', '2'),
(208, 52, '21', '2'),
(209, 53, '70', '2'),
(210, 53, '64', '2'),
(211, 53, '34', '2'),
(212, 53, '56', '1'),
(213, 54, '9', '2'),
(214, 54, '14', '1'),
(215, 54, '24', '2'),
(216, 54, '13', '2'),
(217, 55, '49', '1'),
(218, 55, '42', '2'),
(219, 55, '64', '2'),
(220, 55, '94', '2'),
(221, 56, '16', '2'),
(222, 56, '3', '2'),
(223, 56, '8', '1'),
(224, 56, '6', '2'),
(225, 57, '100', '2'),
(226, 57, '1', '2'),
(227, 57, '20', '2'),
(228, 57, '10', '1'),
(229, 58, '6', '1'),
(230, 58, '12', '2'),
(231, 58, '4', '2'),
(232, 58, '1', '2'),
(233, 59, '10', '2'),
(234, 59, '4', '2'),
(235, 59, '1', '1'),
(236, 59, '2', '2'),
(237, 60, '6', '2'),
(238, 60, '3', '1'),
(239, 60, '9', '2'),
(240, 60, '12', '2'),
(241, 61, '24', '2'),
(242, 61, '18', '1'),
(243, 61, '12', '2'),
(244, 61, '10', '2'),
(245, 62, '64', '2'),
(246, 62, '52', '2'),
(247, 62, '34', '2'),
(248, 62, '48', '1'),
(249, 63, '30', '1'),
(250, 63, '36', '2'),
(251, 63, '20', '2'),
(252, 63, '24', '2'),
(253, 64, '9', '2'),
(254, 64, '6', '2'),
(255, 64, '18', '2'),
(256, 64, '12', '1'),
(257, 65, '28', '2'),
(258, 65, '37', '2'),
(259, 65, '45', '2'),
(260, 65, '36', '1'),
(261, 66, '80', '1'),
(262, 66, '40', '2'),
(263, 66, '23', '2'),
(264, 66, '79', '2'),
(265, 67, '20', '2'),
(266, 67, '24', '2'),
(267, 67, '32', '1'),
(268, 67, '36', '2'),
(269, 68, '48', '2'),
(270, 68, '64', '2'),
(271, 68, '68', '2'),
(272, 68, '40', '1'),
(277, 70, '77', '2'),
(278, 70, '81', '2'),
(279, 70, '72', '1'),
(280, 70, '64', '2'),
(281, 71, '110', '2'),
(282, 71, '90', '1'),
(283, 71, '91', '2'),
(284, 71, '89', '2'),
(285, 72, '36', '1'),
(286, 72, '47', '2'),
(287, 72, '32', '2'),
(288, 72, '31', '2'),
(289, 73, '66', '2'),
(290, 73, '56', '2'),
(291, 73, '53', '2'),
(292, 73, '63', '1'),
(293, 74, '15', '2'),
(294, 74, '18', '1'),
(295, 74, '22', '2'),
(296, 74, '14', '2'),
(297, 75, '99', '2'),
(298, 75, '89', '2'),
(299, 75, '91', '2'),
(300, 75, '81', '1'),
(301, 76, '24', '1'),
(302, 76, '21', '2'),
(303, 76, '28', '2'),
(304, 76, '32', '2');

-- --------------------------------------------------------

--
-- Table structure for table `les`
--

CREATE TABLE `les` (
  `LesID` int(11) NOT NULL,
  `LesonderwerpID` int(11) NOT NULL,
  `NiveauID` int(11) DEFAULT NULL,
  `Uitleg` text,
  `lesNaam` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `les`
--

INSERT INTO `les` (`LesID`, `LesonderwerpID`, `NiveauID`, `Uitleg`, `lesNaam`) VALUES
(3, 1, NULL, 'Verliefde getallen zijn twee getallen die samen 10 zijn, bijvoorbeeld 4 + 6 of 5 + 5.\n\nBij deze les krijg je een getal te zien en je moet hierbij het verliefde getal zoeken, dus je moet het getal kiezen die het samen 10 maakt. ', 'Verliefde getallen'),
(4, 1, NULL, NULL, 'Tientallen'),
(6, 9, NULL, NULL, 'Zoogdieren'),
(7, 9, NULL, NULL, 'Vogels'),
(9, 9, NULL, NULL, 'Vissen'),
(13, 16, NULL, NULL, 'Little animals'),
(16, 2, NULL, NULL, 'Het leven van de boeren en jagers'),
(19, 9, NULL, NULL, 'Reptielen'),
(21, 14, NULL, NULL, 'Stam'),
(22, 14, NULL, NULL, 'Verleden tijd'),
(23, 14, NULL, NULL, 'Stam + T'),
(26, 16, NULL, NULL, 'Baby animals'),
(28, 8, NULL, NULL, 'Bomen'),
(29, 16, NULL, 'Zoek het juiste geluid of de juiste naam van het dier bij de vraag.', 'Farm Animals'),
(30, 6, NULL, 'Zoek de juiste antwoorden bij de tafeltjes.', 'Tafel van 2'),
(31, 6, NULL, 'Zoek de juiste antwoorden bij de tafeltjes.', 'Tafel van 3'),
(32, 6, NULL, 'Zoek de juiste antwoorden bij de tafeltjes.', 'Tafel van 4'),
(33, 6, NULL, 'Zoek de juiste antwoorden bij de tafeltjes.', 'Tafel van 5'),
(34, 6, NULL, 'Zoek de juiste antwoorden bij de tafeltjes.', 'Tafel van 10'),
(35, 19, NULL, 'Zoek het juiste Nederlandse woord bij het Engelse voorbeeld\r\n', 'Food'),
(36, 19, NULL, 'Zoek het juiste woord bij de cadeautjes!\r\n', 'Presents'),
(37, 6, NULL, 'Zoek de juiste antwoorden bij de tafeltjes.\r\n', 'Tafel van 7'),
(38, 6, NULL, 'Zoek de juiste antwoorden bij de tafeltjes.\r\n', 'Tafel van 1'),
(39, 6, NULL, 'Zoek de juiste antwoorden bij de tafeltjes.\r\n', 'Tafel van 6'),
(40, 6, NULL, 'Zoek de juiste antwoorden bij de tafeltjes.\r\n', 'Tafel van 8'),
(41, 6, NULL, 'Zoek de juiste antwoorden bij de tafeltjes.\r\n', 'Tafel van 9 '),
(42, 1, NULL, 'Lees de vraag aandachtig en reken het sommetje uit.\r\n', 'Verhaalsommetjes'),
(43, 1, NULL, 'SAdokskamlaegr\r\n', 'Fruit optellen'),
(44, 1, NULL, 'Mama doet boodschappen bij de supermarkt, hou jij bij hoeveel spullen mama koopt?\r\n', 'Boodschappen doen');

-- --------------------------------------------------------

--
-- Table structure for table `lesonderwerp`
--

CREATE TABLE `lesonderwerp` (
  `LesonderwerpID` int(11) NOT NULL,
  `Omschrijving` varchar(26) NOT NULL,
  `VakID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `lesonderwerp`
--

INSERT INTO `lesonderwerp` (`LesonderwerpID`, `Omschrijving`, `VakID`) VALUES
(1, 'Optellen', 2),
(2, 'Boeren en jagers', 1),
(3, 'Romeinse tijd', 1),
(4, 'Breuken', 2),
(5, 'Delen en vermenigvuldigen', 2),
(6, 'Tafeltjes', 2),
(8, 'Planten', 3),
(9, 'Diersoorten', 3),
(10, 'Het lichaam', 3),
(11, 'Ridders en soldaten', 1),
(12, 'Meervoud', 4),
(13, 'Begrijpend lezen', 4),
(14, 'Wekwoorden', 4),
(15, 'The Classroom', 5),
(16, 'Animals', 5),
(17, 'Colours', 5),
(18, 'Planten en bomen', 3),
(19, 'Christmas', 5),
(20, 'Negatieve getallen', 2);

-- --------------------------------------------------------

--
-- Table structure for table `niveau`
--

CREATE TABLE `niveau` (
  `NiveauID` int(11) NOT NULL,
  `LesID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `planning`
--

CREATE TABLE `planning` (
  `id` int(11) NOT NULL,
  `leerlingid` int(11) NOT NULL,
  `lesid` int(11) NOT NULL,
  `datum` date NOT NULL,
  `lesnaam` varchar(50) NOT NULL,
  `usrname` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `planning`
--

INSERT INTO `planning` (`id`, `leerlingid`, `lesid`, `datum`, `lesnaam`, `usrname`) VALUES
(4, 1, 7, '2017-01-20', 'Vogels', 'leerling'),
(7, 1, 16, '2017-01-31', 'Het leven van de boeren en jagers', 'leerling'),
(8, 3, 16, '2017-01-20', 'Het leven van de boeren en jagers', 'michellebroens'),
(9, 1, 3, '2017-01-13', 'Verliefde getallen', 'leerling'),
(10, 1, 32, '2017-01-12', 'Tafel van 4', 'leerling'),
(12, 1, 30, '2017-01-01', 'Tafel van 2', 'leerling'),
(13, 1, 31, '2017-01-01', 'Tafel van 3', 'leerling'),
(14, 1, 33, '2017-01-01', 'Tafel van 5', 'leerling'),
(15, 1, 34, '2017-01-01', 'Tafel van 10', 'leerling'),
(16, 1, 38, '2017-01-11', 'Tafel van 1', 'leerling'),
(17, 1, 39, '2017-01-11', 'Tafel van 6', 'leerling'),
(18, 1, 40, '2017-01-11', 'Tafel van 8', 'leerling'),
(19, 1, 41, '2017-01-11', 'Tafel van 9 ', 'leerling'),
(20, 1, 37, '2017-01-11', 'Tafel van 7', 'leerling');

-- --------------------------------------------------------

--
-- Table structure for table `rol`
--

CREATE TABLE `rol` (
  `RolID` int(11) NOT NULL,
  `Omschrijving` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `toetsplanning`
--

CREATE TABLE `toetsplanning` (
  `id` int(11) NOT NULL,
  `lesonderwerpid` int(11) NOT NULL,
  `usrname` varchar(50) NOT NULL,
  `datum` date NOT NULL,
  `toetsnaam` varchar(75) NOT NULL,
  `leerlingid` int(11) NOT NULL,
  `VakID` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `toetsplanning`
--

INSERT INTO `toetsplanning` (`id`, `lesonderwerpid`, `usrname`, `datum`, `toetsnaam`, `leerlingid`, `VakID`) VALUES
(9, 4, 'michellebroens', '2017-01-25', 'Breuken TOETS', 3, 0),
(11, 20, 'michellebroens', '2017-01-14', 'Negatieve getallen TOETS', 3, 0),
(12, 2, 'leerling', '2017-01-13', 'Boeren en jagers TOETS', 1, 0),
(13, 6, 'leerling', '2017-01-11', 'Tafeltjes', 1, 2),
(17, 13, 'leerling', '2017-02-03', 'Begrijpend lezen', 1, 4),
(15, 16, 'leerling', '2017-01-18', 'Animals', 1, 5),
(16, 19, 'leerling', '2017-01-18', 'Christmas', 1, 5);

-- --------------------------------------------------------

--
-- Table structure for table `toetsresultaten`
--

CREATE TABLE `toetsresultaten` (
  `ToetsResultaatID` int(11) NOT NULL COMMENT 'Toets resultaat id',
  `UserID` int(11) NOT NULL COMMENT 'User id',
  `LesonderwerpID` int(11) NOT NULL COMMENT 'Lesonderwerp id',
  `Resultaat` double NOT NULL COMMENT 'Het cijfer/resultaat'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `toetsresultaten`
--

INSERT INTO `toetsresultaten` (`ToetsResultaatID`, `UserID`, `LesonderwerpID`, `Resultaat`) VALUES
(4, 1, 6, 9.2),
(5, 1, 12, 4.5),
(6, 1, 15, 5.9),
(7, 1, 5, 7.5),
(8, 1, 11, 6.8),
(9, 1, 8, 7.1);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `Username` varchar(32) NOT NULL,
  `Password` varchar(32) NOT NULL,
  `firstName` varchar(32) NOT NULL,
  `lastName` varchar(32) NOT NULL,
  `rolID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `Username`, `Password`, `firstName`, `lastName`, `rolID`) VALUES
(1, 'leerling', '123', 'Piet', 'Jan', 2),
(2, 'docent', '123', 'Henk', 'Klaas', 1),
(3, 'michellebroens', '123', 'Michelle', 'Broens', 2);

-- --------------------------------------------------------

--
-- Table structure for table `vak`
--

CREATE TABLE `vak` (
  `VakID` int(11) NOT NULL,
  `Omschrijving` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vak`
--

INSERT INTO `vak` (`VakID`, `Omschrijving`) VALUES
(1, 'Geschiedenis'),
(2, 'Rekenen'),
(3, 'Biologie'),
(4, 'Nederlands'),
(5, 'Engels');

-- --------------------------------------------------------

--
-- Table structure for table `voortgang`
--

CREATE TABLE `voortgang` (
  `VoortgangID` int(11) NOT NULL,
  `UserID` int(10) NOT NULL,
  `LesID` int(10) NOT NULL,
  `LesonderwerpID` int(11) NOT NULL,
  `Voortgang` int(1) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `voortgang`
--

INSERT INTO `voortgang` (`VoortgangID`, `UserID`, `LesID`, `LesonderwerpID`, `Voortgang`) VALUES
(1, 1, 30, 6, 1),
(2, 1, 31, 6, 1),
(3, 1, 32, 6, 1),
(4, 1, 33, 6, 1),
(5, 1, 34, 6, 1),
(6, 1, 37, 6, 1),
(7, 1, 38, 6, 1),
(8, 1, 39, 6, 1),
(9, 1, 40, 6, 1),
(10, 1, 41, 6, 1);

-- --------------------------------------------------------

--
-- Table structure for table `vragen`
--

CREATE TABLE `vragen` (
  `VraagID` int(11) NOT NULL,
  `Vraag` varchar(50) NOT NULL,
  `LesID` int(11) NOT NULL,
  `LesonderwerpID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vragen`
--

INSERT INTO `vragen` (`VraagID`, `Vraag`, `LesID`, `LesonderwerpID`) VALUES
(6, 'Welk getal is verliefd op 6?', 3, 1),
(7, 'Welk getal is verliefd op 2?', 3, 1),
(8, 'Welk getal is verliefd op 9?', 3, 1),
(9, 'Welk getal is verliefd op 3?', 3, 1),
(10, 'Welk getal is verliefd op 5?', 3, 1),
(11, 'Welk dier is een Farm Animal?', 29, 16),
(12, 'Wat is het woord voor varken in het engels?', 29, 16),
(13, 'Wat voor geluid maakt een "Cow"?', 29, 16),
(14, 'Hoeveel poten heeft een "Sheep"?', 29, 16),
(15, 'Wat voor geluid maakt een "Chicken"?', 29, 16),
(16, '2 x 2 =', 30, 6),
(17, '2 x 8 =', 30, 6),
(18, '2 x 10 = ', 30, 6),
(19, '2 x 4 = ', 30, 6),
(20, '2 x 5 = ', 30, 6),
(21, '3 x 1 =', 31, 6),
(22, '3 x 7 =', 31, 6),
(23, '3 x 5 =', 31, 6),
(24, '3 x 9 =', 31, 6),
(25, '3 x 4 =', 31, 6),
(26, '4 x 10 =', 32, 6),
(27, '4 x 5 =', 32, 6),
(28, '4 x 2 =', 32, 6),
(29, '4 x 8 =', 32, 6),
(30, '4 x 4 =', 32, 6),
(31, '5 x 9 =', 33, 6),
(32, '5 x 2 =', 33, 6),
(33, '5 x 4 =', 33, 6),
(34, '5 x 10 =', 33, 6),
(35, '5 x 6 =', 33, 6),
(36, '10 x 8 =', 34, 6),
(37, '10 x 3 =', 34, 6),
(38, '10 x 5 =', 34, 6),
(39, '10 x 10 =', 34, 6),
(40, '10 x 7 =', 34, 6),
(41, 'Candycane', 35, 19),
(42, 'Turkey', 35, 19),
(43, 'Wine', 35, 19),
(44, 'Steak', 35, 19),
(45, 'Icecake', 35, 19),
(46, 'Ketting', 36, 19),
(47, 'Guitar', 36, 19),
(48, 'Socks', 36, 19),
(49, 'Armband', 36, 19),
(50, '7 x 10 =', 37, 6),
(52, '7 x 4 = ', 37, 6),
(53, '7 x 8 = ', 37, 6),
(54, '7 x 2 =', 37, 6),
(55, '7 x 7 =', 37, 6),
(56, '1 x 8 =', 38, 6),
(57, '1 x 10 =', 38, 6),
(58, '1 x 6 =', 38, 6),
(59, '1 x 1 =', 38, 6),
(60, '1 x 3 =', 38, 6),
(61, '6 x 3 = ', 39, 6),
(62, '6 x 8 =', 39, 6),
(63, '6 x 5 = ', 39, 6),
(64, '6 x 2 =', 39, 6),
(65, '6 x 6 =', 39, 6),
(66, '8 x 10 =', 40, 6),
(67, '8 x 4 =', 40, 6),
(68, '8 x 5 =', 40, 6),
(70, '8 x 9 =', 40, 6),
(71, '9 x 10 =', 41, 6),
(72, '9 x 4 =', 41, 6),
(73, '9 x 7 =', 41, 6),
(74, '9 x 2 =', 41, 6),
(75, '9 x 9 =', 41, 6),
(76, '8 x 3 =', 40, 6);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `antwoorden`
--
ALTER TABLE `antwoorden`
  ADD PRIMARY KEY (`AntwoordID`);

--
-- Indexes for table `les`
--
ALTER TABLE `les`
  ADD PRIMARY KEY (`LesID`);

--
-- Indexes for table `lesonderwerp`
--
ALTER TABLE `lesonderwerp`
  ADD PRIMARY KEY (`LesonderwerpID`);

--
-- Indexes for table `niveau`
--
ALTER TABLE `niveau`
  ADD PRIMARY KEY (`NiveauID`);

--
-- Indexes for table `planning`
--
ALTER TABLE `planning`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `rol`
--
ALTER TABLE `rol`
  ADD PRIMARY KEY (`RolID`);

--
-- Indexes for table `toetsplanning`
--
ALTER TABLE `toetsplanning`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `toetsresultaten`
--
ALTER TABLE `toetsresultaten`
  ADD PRIMARY KEY (`ToetsResultaatID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`);

--
-- Indexes for table `vak`
--
ALTER TABLE `vak`
  ADD PRIMARY KEY (`VakID`);

--
-- Indexes for table `voortgang`
--
ALTER TABLE `voortgang`
  ADD PRIMARY KEY (`VoortgangID`);

--
-- Indexes for table `vragen`
--
ALTER TABLE `vragen`
  ADD PRIMARY KEY (`VraagID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `antwoorden`
--
ALTER TABLE `antwoorden`
  MODIFY `AntwoordID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=305;
--
-- AUTO_INCREMENT for table `les`
--
ALTER TABLE `les`
  MODIFY `LesID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;
--
-- AUTO_INCREMENT for table `lesonderwerp`
--
ALTER TABLE `lesonderwerp`
  MODIFY `LesonderwerpID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT for table `niveau`
--
ALTER TABLE `niveau`
  MODIFY `NiveauID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `planning`
--
ALTER TABLE `planning`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT for table `rol`
--
ALTER TABLE `rol`
  MODIFY `RolID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `toetsplanning`
--
ALTER TABLE `toetsplanning`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
--
-- AUTO_INCREMENT for table `toetsresultaten`
--
ALTER TABLE `toetsresultaten`
  MODIFY `ToetsResultaatID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Toets resultaat id', AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `vak`
--
ALTER TABLE `vak`
  MODIFY `VakID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `voortgang`
--
ALTER TABLE `voortgang`
  MODIFY `VoortgangID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `vragen`
--
ALTER TABLE `vragen`
  MODIFY `VraagID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=77;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
