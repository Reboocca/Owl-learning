-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Gegenereerd op: 17 dec 2016 om 18:53
-- Serverversie: 10.1.8-MariaDB
-- PHP-versie: 5.6.14

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
-- Tabelstructuur voor tabel `antwoorden`
--

CREATE TABLE `antwoorden` (
  `AntwoordID` int(11) NOT NULL,
  `VraagID` int(11) NOT NULL,
  `Antwoord` varchar(20) NOT NULL,
  `Juist_onjuist` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `les`
--

CREATE TABLE `les` (
  `LesID` int(11) NOT NULL,
  `LesonderwerpID` int(11) NOT NULL,
  `NiveauID` int(11) DEFAULT NULL,
  `Uitleg` varchar(100) DEFAULT NULL,
  `lesNaam` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `les`
--

INSERT INTO `les` (`LesID`, `LesonderwerpID`, `NiveauID`, `Uitleg`, `lesNaam`) VALUES
(3, 1, NULL, NULL, 'Verliefde getallen'),
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
(28, 8, NULL, NULL, 'Bomen');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `lesonderwerp`
--

CREATE TABLE `lesonderwerp` (
  `LesonderwerpID` int(11) NOT NULL,
  `Omschrijving` varchar(26) NOT NULL,
  `VakID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `lesonderwerp`
--

INSERT INTO `lesonderwerp` (`LesonderwerpID`, `Omschrijving`, `VakID`) VALUES
(1, 'Optellen', 2),
(2, 'Boeren en jagers', 1),
(3, 'Romeinse tijd', 1),
(4, 'Breuken', 2),
(5, 'Delen en vermenigvuldigen', 2),
(6, 'Tafeltjes', 2),
(7, 'Delen en vermenigvuldigen', 2),
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
-- Tabelstructuur voor tabel `niveau`
--

CREATE TABLE `niveau` (
  `NiveauID` int(11) NOT NULL,
  `LesID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rol`
--

CREATE TABLE `rol` (
  `RolID` int(11) NOT NULL,
  `Omschrijving` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
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
-- Gegevens worden geëxporteerd voor tabel `users`
--

INSERT INTO `users` (`UserID`, `Username`, `Password`, `firstName`, `lastName`, `rolID`) VALUES
(1, 'leerling', '123', 'Piet', 'Jan', 2),
(2, 'docent', '123', 'Henk', 'Klaas', 1);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `vak`
--

CREATE TABLE `vak` (
  `VakID` int(11) NOT NULL,
  `Omschrijving` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `vak`
--

INSERT INTO `vak` (`VakID`, `Omschrijving`) VALUES
(1, 'Geschiedenis'),
(2, 'Rekenen'),
(3, 'Biologie'),
(4, 'Nederlands'),
(5, 'Engels');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `vragen`
--

CREATE TABLE `vragen` (
  `VraagID` int(11) NOT NULL,
  `Vraag` varchar(50) NOT NULL,
  `LesID` int(11) NOT NULL,
  `AntwoordID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `antwoorden`
--
ALTER TABLE `antwoorden`
  ADD PRIMARY KEY (`AntwoordID`);

--
-- Indexen voor tabel `les`
--
ALTER TABLE `les`
  ADD PRIMARY KEY (`LesID`);

--
-- Indexen voor tabel `lesonderwerp`
--
ALTER TABLE `lesonderwerp`
  ADD PRIMARY KEY (`LesonderwerpID`);

--
-- Indexen voor tabel `niveau`
--
ALTER TABLE `niveau`
  ADD PRIMARY KEY (`NiveauID`);

--
-- Indexen voor tabel `rol`
--
ALTER TABLE `rol`
  ADD PRIMARY KEY (`RolID`);

--
-- Indexen voor tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`);

--
-- Indexen voor tabel `vak`
--
ALTER TABLE `vak`
  ADD PRIMARY KEY (`VakID`);

--
-- Indexen voor tabel `vragen`
--
ALTER TABLE `vragen`
  ADD PRIMARY KEY (`VraagID`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `antwoorden`
--
ALTER TABLE `antwoorden`
  MODIFY `AntwoordID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT voor een tabel `les`
--
ALTER TABLE `les`
  MODIFY `LesID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;
--
-- AUTO_INCREMENT voor een tabel `lesonderwerp`
--
ALTER TABLE `lesonderwerp`
  MODIFY `LesonderwerpID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT voor een tabel `niveau`
--
ALTER TABLE `niveau`
  MODIFY `NiveauID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT voor een tabel `rol`
--
ALTER TABLE `rol`
  MODIFY `RolID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT voor een tabel `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT voor een tabel `vak`
--
ALTER TABLE `vak`
  MODIFY `VakID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT voor een tabel `vragen`
--
ALTER TABLE `vragen`
  MODIFY `VraagID` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
