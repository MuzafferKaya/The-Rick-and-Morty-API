import React from "react";
import Link from 'next/link';
import Image from "next/image";
import Style from "@/styles/page.module.css";
import Favorite from "./Favorite";
import { Provider } from 'react-redux';
import store from '@/redux/store';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

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

const CharacterCard: React.FC<{ character: Character | null }> = ({ character }) => {
    if (!character)
        return;

    return (
        <Provider store={store}>
            <div className={`card h-100 shadow-sm ${Style.characterCard}`}>
                <div className="row g-0">
                    <div className="col-md-4">
                        <Image
                            src={character.image}
                            width={500}
                            height={500}
                            alt={character.name}
                            className='img-fluid rounded-start'
                        />
                        <Favorite character={character} />
                        <ToastContainer />
                    </div>
                    <div className="col-md-8">
                        <div className="card-body d-flex flex-column justify-content-between">
                            <div>
                                <h5 className="card-title">
                                    <Link href={`/characters/${character.id}`}>{character.name}</Link>
                                </h5>
                                <p className="card-text">
                                    <small className="text-body-secondary">{character.status} - {character.species}</small><br />
                                    First seen in: {character.origin.name}<br />
                                    Last known location: {character.location.name}
                                </p>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </Provider>
    );
};

export default CharacterCard;