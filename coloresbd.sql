-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 12-06-2024 a las 20:58:04
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `coloresbd`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `textura`
--

CREATE TABLE `textura` (
  `id` int(11) NOT NULL,
  `descripcion_origen` varchar(255) NOT NULL,
  `cR_origen` int(11) NOT NULL,
  `cG_origen` int(11) NOT NULL,
  `cB_origen` int(11) NOT NULL,
  `hex_origen` varchar(7) NOT NULL,
  `descripcion_destino` varchar(255) NOT NULL,
  `cR_destino` int(11) NOT NULL,
  `cG_destino` int(11) NOT NULL,
  `cB_destino` int(11) NOT NULL,
  `hex_destino` varchar(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `textura`
--

INSERT INTO `textura` (`id`, `descripcion_origen`, `cR_origen`, `cG_origen`, `cB_origen`, `hex_origen`, `descripcion_destino`, `cR_destino`, `cG_destino`, `cB_destino`, `hex_destino`) VALUES
(1, 'Rojo Claro', 255, 102, 102, '#FF6666', 'Rojo Oscuro', 139, 0, 0, '#8B0000'),
(2, 'Verde Claro', 102, 255, 102, '#66FF66', 'Verde Oscuro', 0, 100, 0, '#006400'),
(3, 'Azul Claro', 102, 102, 255, '#6666FF', 'Azul Oscuro', 0, 0, 139, '#00008B'),
(4, 'Amarillo Claro', 255, 255, 102, '#FFFF66', 'Amarillo Oscuro', 204, 204, 0, '#CCCC00'),
(5, 'Cyan Claro', 102, 255, 255, '#66FFFF', 'Cyan Oscuro', 0, 139, 139, '#008B8B'),
(6, 'Magenta Claro', 255, 102, 255, '#FF66FF', 'Magenta Oscuro', 139, 0, 139, '#8B008B'),
(7, 'Naranja Claro', 255, 178, 102, '#FFB266', 'Naranja Oscuro', 255, 69, 0, '#FF4500'),
(8, 'Rosa Claro', 255, 182, 193, '#FFB6C1', 'Rosa Oscuro', 199, 21, 133, '#C71585'),
(9, 'Marrón Claro', 210, 180, 140, '#D2B48C', 'Marrón Oscuro', 101, 67, 33, '#654321'),
(10, 'Púrpura Claro', 160, 32, 240, '#A020F0', 'Púrpura Oscuro', 75, 0, 130, '#4B0082'),
(11, 'Gris Claro', 211, 211, 211, '#D3D3D3', 'Gris Oscuro', 169, 169, 169, '#A9A9A9'),
(12, 'Turquesa Claro', 64, 224, 208, '#40E0D0', 'Turquesa Oscuro', 0, 206, 209, '#00CED1'),
(13, 'Oliva Claro', 128, 128, 0, '#808000', 'Oliva Oscuro', 85, 107, 47, '#556B2F'),
(14, 'Dorado Claro', 255, 215, 0, '#FFD700', 'Dorado Oscuro', 184, 134, 11, '#B8860B'),
(15, 'Plateado Claro', 192, 192, 192, '#C0C0C0', 'Plateado Oscuro', 169, 169, 169, '#A9A9A9'),
(16, 'Lavanda Claro', 230, 230, 250, '#E6E6FA', 'Lavanda Oscuro', 191, 191, 255, '#BFBFFF'),
(17, 'Menta Claro', 189, 252, 201, '#BDFCC9', 'Menta Oscuro', 144, 238, 144, '#90EE90'),
(18, 'Durazno Claro', 255, 218, 185, '#FFDAB9', 'Durazno Oscuro', 255, 160, 122, '#FFA07A'),
(19, 'Coral Claro', 240, 128, 128, '#F08080', 'Coral Oscuro', 205, 92, 92, '#CD5C5C'),
(20, 'Salmón Claro', 255, 160, 122, '#FFA07A', 'Salmón Oscuro', 233, 150, 122, '#E9967A'),
(21, 'Violeta Claro', 238, 130, 238, '#EE82EE', 'Violeta Oscuro', 148, 0, 211, '#9400D3'),
(22, 'Marfil Claro', 255, 255, 240, '#FFFFF0', 'Marfil Oscuro', 240, 230, 140, '#F0E68C'),
(23, 'Orquídea Claro', 218, 112, 214, '#DA70D6', 'Orquídea Oscuro', 186, 85, 211, '#BA55D3'),
(24, 'Tomate Claro', 255, 99, 71, '#FF6347', 'Tomate Oscuro', 255, 69, 0, '#FF4500'),
(25, 'Aguamarina Claro', 127, 255, 212, '#7FFFD4', 'Aguamarina Oscuro', 69, 139, 116, '#458B74'),
(26, 'Cobre Claro', 184, 115, 51, '#B87333', 'Cobre Oscuro', 139, 69, 19, '#8B4513'),
(27, 'Champán Claro', 247, 231, 206, '#F7E7CE', 'Champán Oscuro', 241, 209, 183, '#F1D1B7'),
(28, 'Perla Claro', 234, 224, 200, '#EAE0C8', 'Perla Oscuro', 201, 192, 187, '#C9C0BB'),
(29, 'Esmeralda Claro', 80, 200, 120, '#50C878', 'Esmeralda Oscuro', 0, 128, 0, '#008000'),
(30, 'Ámbar Claro', 255, 191, 0, '#FFBF00', 'Ámbar Oscuro', 255, 140, 0, '#FF8C00'),
(31, 'Cereza Claro', 222, 49, 99, '#DE3163', 'Cereza Oscuro', 139, 0, 0, '#8B0000'),
(32, 'Zafiro Claro', 8, 37, 103, '#082567', 'Zafiro Oscuro', 0, 0, 128, '#000080'),
(33, 'Rubí Claro', 224, 17, 95, '#E0115F', 'Rubí Oscuro', 139, 0, 0, '#8B0000'),
(34, 'Azul Acero Claro', 70, 130, 180, '#4682B4', 'Azul Acero Oscuro', 54, 100, 139, '#36648B'),
(35, 'Ceniza Claro', 178, 190, 181, '#B2BEB5', 'Ceniza Oscuro', 123, 123, 123, '#7B7B7B'),
(36, 'Avena Claro', 204, 204, 102, '#CCCC66', 'Avena Oscuro', 153, 153, 51, '#999933'),
(37, 'Azul Bebé Claro', 137, 207, 240, '#89CFF0', 'Azul Bebé Oscuro', 109, 158, 235, '#6D9EEB'),
(38, 'Rojo Vivo Claro', 255, 0, 0, '#FF0000', 'Rojo Vivo Oscuro', 139, 0, 0, '#8B0000'),
(39, 'Verde Lima Claro', 50, 205, 50, '#32CD32', 'Verde Lima Oscuro', 34, 139, 34, '#228B22'),
(40, 'Azul Marino Claro', 70, 130, 180, '#4682B4', 'Azul Marino Oscuro', 0, 0, 139, '#00008B');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
