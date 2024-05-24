'use client';

import EpisodeCard from "@/components/EpisodeCard";
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
    const [episodes, setEpisodes] = useState<Episode[]>([]);
    const [character, setCharacter] = useState<Character | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            const response = await fetch(`https://rickandmortyapi.com/api/character/${params.id}`);
            const data = await response.json();
            const episodeIds = data.episode.map((url: string) => {
                const urlParts = url.split('/');
                return urlParts[urlParts.length - 1];
            });

            const episodeResponse = await fetch(`https://rickandmortyapi.com/api/episode/${episodeIds.join(',')}`);
            setEpisodes(await episodeResponse.json());
            setCharacter(data);
        };

        fetchData();
    }, [params.id]);

    return (
        <div className="container">
            <div className="row">
                <div className="col-6 col-lg-6 col-md-12 mb-3 d-flex justify-content-center">
                    <CharacterCard character={character} />
                </div>
            </div>
            <div className="row">
                {episodes.map((episode, index) => (
                    <div className="col-3 mb-3" key={index}>
                        <EpisodeCard key={episode.id} episode={episode} />
                    </div>
                ))}
            </div>
        </div>
    );
}

export default Home;