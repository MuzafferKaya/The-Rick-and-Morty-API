'use client';

import CharacterCard from "@/components/CharacterCard";
import React, { useState, useEffect } from "react";
import Pagination from "@/components/Pagination";
import Filter from "@/components/Filter";

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

interface Info {
    count: number;
    pages: number;
    next: string | null;
    prev: string | null;
};

const Home: React.FC = () => {
    const [character, setCharacter] = useState<Character[]>([]);
    const [info, setInfo] = useState<Info>({ count: 0, pages: 0, next: null, prev: null });
    const [pageNumber, setPageNumber] = useState<number>(1);
    const [filters, setFilters] = useState({ name: '', status: '', species: '', type: '', gender: '', });
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const query = new URLSearchParams({
                    ...filters,
                    page: pageNumber.toString(),
                }).toString();

                const response = await fetch(`https://rickandmortyapi.com/api/character?${query}`);
                const data = await response.json();
                if (data.error)
                    setError(data.error);
                else {
                    setCharacter(data.results || []);
                    setInfo(data.info);
                    setError(null);
                }
            } catch (error) {
                setError('Failed to fetch data');
            }
        };

        fetchData();
    }, [pageNumber, filters]);

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setFilters({
            ...filters,
            [name]: value,
        });
    };

    const handlePageChange = (newPage: number) => {
        setPageNumber(newPage);
    };

    return (
        <div className="container">
            <div className="row">
                <div className="col-2 mb-3">
                    <Filter filters={filters} onChange={handleInputChange} />
                </div>
                <div className="col-9">
                    {error ? (
                        <div className="alert alert-info" role="alert">
                            Burada hiçbir şey yok.
                        </div>
                    ) : (
                        <>
                            <div className="row">
                                {character.map((character, index) => (
                                    <div className="col-6 col-lg-6 col-md-12 mb-3 d-flex justify-content-center" key={index}>
                                        <CharacterCard key={character.id} character={character} />
                                    </div>
                                ))}
                            </div>
                            <Pagination
                                info={info}
                                currentPage={pageNumber}
                                basePath="/characters"
                                onPageChange={handlePageChange}
                            />
                        </>
                    )}
                </div>
            </div>
        </div>
    );
}

export default Home;