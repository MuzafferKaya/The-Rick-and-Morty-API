'use client';

import EpisodeCard from "@/components/EpisodeCard";
import React, { useState, useEffect } from "react";
import Pagination from "@/components/Pagination";

interface Episode {
    id: number;
    name: string;
    air_date: string;
    episode: string;
};

interface Info {
    count: number;
    pages: number;
    next: string | null;
    prev: string | null;
};

const Home: React.FC = () => {
    const [episodes, setEpisodes] = useState<Episode[]>([]);
    const [info, setInfo] = useState<Info>({ count: 0, pages: 0, next: null, prev: null });
    const [pageNumber, setPageNumber] = useState<number>(1);

    useEffect(() => {
        const fetchData = async () => {
            const response = await fetch(`https://rickandmortyapi.com/api/episode?page=${pageNumber}`);
            const data = await response.json();
            setEpisodes(data.results);
            setInfo(data.info);
        };

        fetchData();
    }, [pageNumber]);

    const handlePageChange = (newPage: number) => {
        setPageNumber(newPage);
    };

    return (
        <div className="container">
            <div className="row">
                {episodes.map((episode, index) => (
                    <div className="col-3 mb-3" key={index}>
                        <EpisodeCard key={episode.id} episode={episode} />
                    </div>
                ))}
                <Pagination
                    info={info}
                    currentPage={pageNumber}
                    basePath="/episodes"
                    onPageChange={handlePageChange}
                />
            </div>
        </div>
    );
}

export default Home;