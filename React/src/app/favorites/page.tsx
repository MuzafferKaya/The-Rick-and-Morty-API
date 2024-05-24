'use client';

import CharacterCard from "@/components/CharacterCard";
import React, { useState, useEffect } from "react";
import { useRouter } from 'next/navigation';
import Swal from 'sweetalert2';
import 'sweetalert2/src/sweetalert2.scss';

interface Character {
    id: number;
    name: string;
    status: string;
    species: string;
    type: string;
    gender: string;
    origin: {
        name: string;
    };
    location: {
        name: string;
    };
    image: string;
};

const Home: React.FC = () => {
    const router = useRouter()
    const [characters, setCharacters] = useState<Character[]>([]);
    const [favoriteIds, setFavoriteIds] = useState<number[]>([]);

    useEffect(() => {
        if (typeof window !== 'undefined') {
            const storedFavorites = localStorage.getItem('favorites');
            if (storedFavorites) {
                setFavoriteIds(JSON.parse(storedFavorites));
                if (!storedFavorites || JSON.parse(storedFavorites).length === 0) {
                    Swal.fire({
                        title: "Görünüşe göre favori karakteriniz bulunmamaktadır.",
                        text: "Favori karakter eklemeye ne dersiniz? 👀",
                        icon: "warning",
                        showCancelButton: true,
                        confirmButtonColor: "#3085d6",
                        cancelButtonColor: "#d33",
                        confirmButtonText: "Ekle",
                        cancelButtonText: "Ekleme"
                    }).then((result) => {
                        if (result.isConfirmed) {
                            router.push('/characters/');
                        }
                    });
                }
            }
        }
    }, []);

    useEffect(() => {
        const fetchData = async () => {
            if (favoriteIds.length > 0) {
                const response = await fetch(`https://rickandmortyapi.com/api/character/${favoriteIds.join(',')}`);
                const data = await response.json();
                setCharacters(Array.isArray(data) ? data : [data]);
            }
        };

        fetchData();
    }, [favoriteIds]);

    return (
        <div className="container">
            <div className="row">
                {characters.map((character, index) => (
                    <div className="col-6 col-lg-6 col-md-12 mb-3 d-flex justify-content-center" key={index}>
                        <CharacterCard key={character.id} character={character} />
                    </div>
                ))}
            </div>
        </div>
    );
};

export default Home;
