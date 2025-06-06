-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 06 Cze 2025, 12:30
-- Wersja serwera: 10.4.18-MariaDB
-- Wersja PHP: 7.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `fanclubdb`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `albums`
--

CREATE TABLE `albums` (
  `id` int(11) NOT NULL,
  `Title` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `ReleaseDate` date DEFAULT NULL,
  `CoverUrl` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Zrzut danych tabeli `albums`
--

INSERT INTO `albums` (`id`, `Title`, `ReleaseDate`, `CoverUrl`) VALUES
(1, 'Electric Dreams', '2015-09-20', 'https://example.com/covers/electric.jpg'),
(2, 'Neon Skies', '2018-03-10', 'https://example.com/covers/neon.jpg'),
(5, 'dda', NULL, 'ddd');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `concerts`
--

CREATE TABLE `concerts` (
  `id` int(11) NOT NULL,
  `Title` varchar(200) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Date` date NOT NULL,
  `City` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Venue` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `TicketUrl` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Zrzut danych tabeli `concerts`
--

INSERT INTO `concerts` (`id`, `Title`, `Date`, `City`, `Venue`, `TicketUrl`) VALUES
(1, 'Electric Tour - Kraków', '2023-06-15', 'Kraków', 'TAURON Arena', 'https://tickets.example.com/krakow'),
(2, 'Neon Night - Warszawa', '2024-09-12', 'Warszawa', 'Stadion Narodowy', 'https://tickets.example.com/warszawa'),
(6, 'aa', '0001-01-01', 'a', 'a', 'a');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `members`
--

CREATE TABLE `members` (
  `id` int(11) NOT NULL,
  `Name` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Role` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `JoinDate` date DEFAULT NULL,
  `LeaveDate` date DEFAULT NULL,
  `Bio` text COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `PhotoUrl` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Zrzut danych tabeli `members`
--

INSERT INTO `members` (`id`, `Name`, `Role`, `JoinDate`, `LeaveDate`, `Bio`, `PhotoUrl`) VALUES
(1, 'Alex Smith', 'Wokal', '2010-01-01', NULL, 'Frontman zespołu z niesamowitą charyzmą.jj', 'https://example.com/photos/alex.jpg'),
(2, 'Jamie Lee', 'Gitara', '2011-06-15', NULL, 'Pasjonat rockowego brzmienia.', 'https://example.com/photos/jamie.jpg'),
(3, 'Paweł Ulita', 'Gitara', NULL, NULL, 'bio test', 'hhhhhh');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `news`
--

CREATE TABLE `news` (
  `id` int(11) NOT NULL,
  `Title` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Content` text COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `PublishDate` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Zrzut danych tabeli `news`
--

INSERT INTO `news` (`id`, `Title`, `Content`, `PublishDate`) VALUES
(1, 'Nowa trasa koncertowa!', 'Zespół ogłasza letnią trasę po Europie.', '2025-05-31 14:38:08'),
(6, 'aaa', 'a', '2025-06-05 15:34:43');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `photos`
--

CREATE TABLE `photos` (
  `id` int(11) NOT NULL,
  `Title` varchar(200) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Description` text COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Url` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `UploadedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Zrzut danych tabeli `photos`
--

INSERT INTO `photos` (`id`, `Title`, `Description`, `Url`, `UploadedAt`) VALUES
(1, 'Z próby dźwięku', 'Zdjęcie z próby przed koncertem.', 'https://example.com/photos/soundcheck.jpg', '2025-05-31 14:38:08'),
(6, 'ha', 'j', 'h', '2025-06-06 09:08:02');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `setlists`
--

CREATE TABLE `setlists` (
  `id` int(11) NOT NULL,
  `ConcertId` int(11) NOT NULL,
  `SongId` int(11) NOT NULL,
  `SongOrder` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Zrzut danych tabeli `setlists`
--

INSERT INTO `setlists` (`id`, `ConcertId`, `SongId`, `SongOrder`) VALUES
(7, 1, 5, 1),
(8, 1, 1, 2),
(9, 1, 2, 3),
(14, 2, 1, 1),
(15, 2, 3, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `songs`
--

CREATE TABLE `songs` (
  `id` int(11) NOT NULL,
  `AlbumId` int(11) NOT NULL,
  `Title` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Duration` varchar(10) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `TrackNumber` int(11) DEFAULT NULL,
  `Lyrics` text COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Zrzut danych tabeli `songs`
--

INSERT INTO `songs` (`id`, `AlbumId`, `Title`, `Duration`, `TrackNumber`, `Lyrics`) VALUES
(1, 1, 'Midnight Ride', '3:45', 1, 'Let the engine roar...'),
(2, 1, 'Fading Lights', '4:20', 2, 'In the silence of the night...'),
(3, 2, 'Skybound', '3:58', 1, 'Rising high above the storm...'),
(5, 1, 'Psie sny', '1:00', 3, 'ddd'),
(8, 1, 'daa', '2', 4, 'd');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `videos`
--

CREATE TABLE `videos` (
  `id` int(11) NOT NULL,
  `Title` varchar(200) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `YoutubeUrl` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Description` text COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `UploadedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Zrzut danych tabeli `videos`
--

INSERT INTO `videos` (`id`, `Title`, `YoutubeUrl`, `Description`, `UploadedAt`) VALUES
(1, 'Teledysk - Midnight Ridea', 'https://youtube.com/watch?v=abc123', 'Oficjalny teledysk do utworu.', '2025-05-31 14:38:08'),
(7, 'df', 'https://www.youtube.com/konieclistopada', 'df', '2025-06-06 09:17:26'),
(8, 'da', 'https://www.youtube.com/konieclistopada', 'd', '2025-06-06 09:17:26'),
(9, 'Reklamiarze', 'https://www.youtube.com/watch?v=6z9JVDV9d5M&t=1s', 'Teledysk do utworu', '2025-06-06 09:48:49');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `albums`
--
ALTER TABLE `albums`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `concerts`
--
ALTER TABLE `concerts`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `members`
--
ALTER TABLE `members`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `news`
--
ALTER TABLE `news`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `photos`
--
ALTER TABLE `photos`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `setlists`
--
ALTER TABLE `setlists`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ConcertId` (`ConcertId`),
  ADD KEY `SongId` (`SongId`);

--
-- Indeksy dla tabeli `songs`
--
ALTER TABLE `songs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `AlbumId` (`AlbumId`);

--
-- Indeksy dla tabeli `videos`
--
ALTER TABLE `videos`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `albums`
--
ALTER TABLE `albums`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT dla tabeli `concerts`
--
ALTER TABLE `concerts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT dla tabeli `members`
--
ALTER TABLE `members`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT dla tabeli `news`
--
ALTER TABLE `news`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT dla tabeli `photos`
--
ALTER TABLE `photos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT dla tabeli `setlists`
--
ALTER TABLE `setlists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT dla tabeli `songs`
--
ALTER TABLE `songs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT dla tabeli `videos`
--
ALTER TABLE `videos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `setlists`
--
ALTER TABLE `setlists`
  ADD CONSTRAINT `setlists_ibfk_1` FOREIGN KEY (`ConcertId`) REFERENCES `concerts` (`Id`),
  ADD CONSTRAINT `setlists_ibfk_2` FOREIGN KEY (`SongId`) REFERENCES `songs` (`Id`);

--
-- Ograniczenia dla tabeli `songs`
--
ALTER TABLE `songs`
  ADD CONSTRAINT `songs_ibfk_1` FOREIGN KEY (`AlbumId`) REFERENCES `albums` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
