'use client';

import CharacterCard from "@/components/CharacterCard";
import React, { useState, useEffect } from "react";
import { useParams } from "next/navigation";
import Style from "@/styles/page.module.css";

interface Episode {
    id: number;
    name: string;
    air_date: string;
    episode: string;
};

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
    }
    image: string;
};

const Home: React.FC = () => {
    const params = useParams<{ id: string }>();
    const [episode, setEpisode] = useState<Episode | null>(null);
    const [characters, setCharacters] = useState<Character[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            const response = await fetch(`https://rickandmortyapi.com/api/episode/${params.id}`);
            const data = await response.json();
            const characterIds = data.characters.map((url: string) => {
                const urlParts = url.split('/');
                return urlParts[urlParts.length - 1];
            });

            const characterResponse = await fetch(`https://rickandmortyapi.com/api/character/${characterIds.join(',')}`);
            setCharacters(await characterResponse.json());
            setEpisode(data);
        };

        fetchData();
    }, [params.id]);

    return (
        <div className="container">
            <div className={`d-flex justify-content-center align-items-center mb-3 shadow-lg rounded ${Style.episodeHeader}`}>
                <div className="container text-center text-white">
                    <div className={`rounded py-1 ${Style.overlay}`}>
                        <p className="fw-bold display-2">{episode?.name}</p>
                        <p className="display-6">{episode?.episode} - {episode?.air_date}</p>
                    </div>
                </div>
            </div>
            <div className="row">
                {characters.map((character, index) => (
                    <div className="col-6 mb-3 d-flex justify-content-center" key={index}>
                        <CharacterCard key={character.id} character={character} />
                    </div>
                ))}
            </div>
        </div>
    );
}

export default Home;