import React from "react";
import Link from 'next/link';
import Image from "next/image";
import { TbListDetails } from "react-icons/tb";

interface Episode {
    id: number;
    name: string;
    air_date: string;
    episode: string;
};

const EpisodeCard: React.FC<{ episode: Episode | null }> = ({ episode }) => {
    if (!episode)
        return;

    return (
        <div className="card h-100 shadow-sm">
            <Image
                src="/images/bg.jpg"
                width={500}
                height={500}
                alt={episode.name}
                className='img-fluid card-img-top'
            />
            <div className="card-body d-flex flex-column justify-content-between">
                <div>
                    <h5 className="card-title">{episode.name}</h5>
                    <h6 className="card-subtitle mb-2 text-body-secondary">{episode.episode}</h6>
                    <p className="card-text">{episode.air_date}</p>
                </div>
                <Link className="btn btn-light mt-auto d-flex align-items-center" href={`/episodes/${episode.id}`}>
                    <TbListDetails />
                    <span className="ms-1">Episode details</span>
                </Link>
            </div>
        </div>
    );
};

export default EpisodeCard;