-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 11 Gru 2019, 13:49
-- Wersja serwera: 10.1.37-MariaDB
-- Wersja PHP: 7.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `gozabka`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `name` varchar(40) COLLATE utf8_polish_ci NOT NULL,
  `price` varchar(100) COLLATE utf8_polish_ci NOT NULL,
  `description` varchar(200) COLLATE utf8_polish_ci NOT NULL,
  `image` varchar(400) COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `products`
--

INSERT INTO `products` (`id`, `name`, `price`, `description`, `image`) VALUES
(1, 'first1', '100,50', 'first', '70089498_475189803320110_5835137951255756800_n.jpg'),
(74, 'Plyta z zadra w sercu', '99,19', 'Jazz Band Mlynarski-Masecki – Plyta z zadra w sercu – Agora', 'jazzBand.jpg'),
(75, 'SaxesFul', '69,69', 'Polish-Jazz: Piotr Schmidt Quartet - Saxesful', 'saxesFul.jpg'),
(76, 'Kind of Blue', '89,99', 'Kind of Blue – album muzyczny Milesa Davisa', 'Kindofblue.jpg'),
(77, 'Polish Jazz', '52,99', 'Zbigniew Namyslowski, Tomasz Stanko, Adam Makowicz, Paradox, Marianna Wróblewska, Laboratorium', 'PolishJazz.jpg'),
(79, 'fff', '567', 'iii', 'jazzBand.jpg');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(40) COLLATE utf8_polish_ci NOT NULL,
  `password` varchar(40) COLLATE utf8_polish_ci NOT NULL,
  `email` varchar(40) COLLATE utf8_polish_ci NOT NULL,
  `authorized` tinyint(1) NOT NULL,
  `authorizationCode` varchar(40) COLLATE utf8_polish_ci NOT NULL,
  `Enable` varchar(10) COLLATE utf8_polish_ci NOT NULL DEFAULT 'TRUE',
  `type` varchar(40) COLLATE utf8_polish_ci NOT NULL,
  `koszyk` varchar(300) COLLATE utf8_polish_ci NOT NULL,
  `logowania` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`id`, `name`, `password`, `email`, `authorized`, `authorizationCode`, `Enable`, `type`, `koszyk`, `logowania`) VALUES
(6, 'mati', '·«ëµR j ', 'mateusztrial20@interia.pl', 1, '88724', 'TRUE', 'admin', '{\r\n  data: [\r\n    {\r\n      id: 3,\r\n      ilosc: 7\r\n    },\r\n    {\r\n      id: 65,\r\n      ilosc: 7\r\n    },\r\n    {\r\n      id: 64,\r\n      ilosc: 1\r\n    }\r\n  ]\r\n}', 31),
(10, 'mat', '·«ëµR j ', 'mateusztrial20@gmail.com', 0, '3566', 'TRUE', 'user', '{\r\n  data: [\r\n    {\r\n      id: 1,\r\n      ilosc: 6\r\n    },\r\n    {id:4,ilosc:10}\r\n  ]\r\n}', 0),
(13, 'karol', 'vjË¥DÀ«À', 'karolwojtasz@gmail.com', 1, '9219', 'TRUE', 'user', '{\r\n  data: [\r\n    {\r\n      id: 74,\r\n      ilosc: 6\r\n    }\r\n  ]\r\n}', 5),
(14, 'aaa', '·«ëµR j ', 'karolwojtasz@gmail.com', 1, '22533', 'TRUE', 'user', '{\r\n  data: [\r\n    {\r\n      id: 1,\r\n      ilosc: 1\r\n    },\r\n    {\r\n      id: 74,\r\n      ilosc: 1\r\n    },\r\n    {id:75,ilosc:1}\r\n  ]\r\n}', 5);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=80;

--
-- AUTO_INCREMENT dla tabeli `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
