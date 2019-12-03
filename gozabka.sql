-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 04 Gru 2019, 00:53
-- Wersja serwera: 10.1.38-MariaDB
-- Wersja PHP: 7.3.4

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
(1, 'first', '100', 'first', '70089498_475189803320110_5835137951255756800_n.jpg'),
(3, 'second', '200', 'second', 'indeks.jpg'),
(4, 'third', '400', 'third', 'untitled-goose-game-12.jpg'),
(63, 'qwe', '2', 'qweee', '68656437_1449064128566628_8884557576000241664_n.jpg'),
(64, 'next1', '1', 'next1', '69751466_2757784950952547_2823569860406018048_n.jpg'),
(65, 'ewe', '3123', 'ewew', '74529523_2530516867038709_8410846262621896704_n.jpg');

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
  `type` varchar(40) COLLATE utf8_polish_ci NOT NULL,
  `koszyk` varchar(300) COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`id`, `name`, `password`, `email`, `authorized`, `authorizationCode`, `type`, `koszyk`) VALUES
(6, 'mati', '·«ëµR j ', 'mateusztrial20@interia.pl', 1, '88724', 'admin', '{\r\n  data: [\r\n    {\r\n      id: 3,\r\n      ilosc: 7\r\n    },\r\n    {\r\n      id: 65,\r\n      ilosc: 7\r\n    },\r\n    {\r\n      id: 64,\r\n      ilosc: 1\r\n    }\r\n  ]\r\n}'),
(10, 'mat', '·«ëµR j ', 'mateusztrial20@gmail.com', 0, '3566', 'user', '{\r\n  data: [\r\n    {\r\n      id: 1,\r\n      ilosc: 6\r\n    },\r\n    {id:4,ilosc:10}\r\n  ]\r\n}'),
(11, 'mate', '·«ëµR j ', 'mateusztrial20@gmail.com', 1, '64930', 'user', '{\r\n  data: [\r\n    {\r\n      id: 4,\r\n      ilosc: 4\r\n    },\r\n    {\r\n      id: 3,\r\n      ilosc: 5\r\n    }\r\n  ]\r\n}'),
(12, 'mateusz', '·«ëµR j ', 'mateusztrial20@gmail.com', 1, '8919', 'user', '{data:[]}');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=72;

--
-- AUTO_INCREMENT dla tabeli `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
