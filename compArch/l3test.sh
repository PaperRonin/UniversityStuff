#!/usr/bin/env bash

echo -e "\e[H\e[J"

echo -e "\e(0"

#верхняя граница рамки
echo -e "\e[10;5Hlqqqqqqqk"

#левая и правая границцы рамки
for ((i = 11; i < 18; ++i))
do
 echo -e "\e[$i;5Hx"
 echo -e "\e[$i;13Hx"
done

#Нижняя граница рамки
echo -e "\e[18;5Hmqqqqqqqj"

#кончик единицы
echo -e "\e[11;9Ha"
echo -e "\e[12;8Ha"

#единица
for ((i = 12; i < 17; ++i))
do
	echo -e "\e[$i;9Ha"
done

#основание единицы
echo -e "\e[17;7Haaaaa"

echo -e "\e[20;20H"
echo -e "\e(B"

