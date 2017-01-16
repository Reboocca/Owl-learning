-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 16 jan 2017 om 10:16
-- Serverversie: 5.7.14
-- PHP-versie: 5.6.25

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
-- Tabelstructuur voor tabel `toetsplanning`
--

CREATE TABLE `toetsplanning` (
  `id` int(11) NOT NULL,
  `lesonderwerpid` int(11) NOT NULL,
  `usrname` varchar(50) NOT NULL,
  `datum` date NOT NULL,
  `toetsnaam` varchar(75) NOT NULL,
  `leerlingid` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `toetsplanning`
--

INSERT INTO `toetsplanning` (`id`, `lesonderwerpid`, `usrname`, `datum`, `toetsnaam`, `leerlingid`) VALUES
(9, 4, 'michellebroens', '2017-01-25', 'Breuken TOETS', 3),
(11, 20, 'michellebroens', '2017-01-14', 'Negatieve getallen TOETS', 3),
(12, 2, 'leerling', '2017-01-13', 'Boeren en jagers TOETS', 1);

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `toetsplanning`
--
ALTER TABLE `toetsplanning`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `toetsplanning`
--
ALTER TABLE `toetsplanning`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
