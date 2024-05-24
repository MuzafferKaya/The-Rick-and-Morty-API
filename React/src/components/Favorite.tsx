import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { addFavorite, removeFavorite } from '@/redux/actions/favoriteActions';
import { RootState } from '@/redux/store';
import { MdFavorite, MdFavoriteBorder } from 'react-icons/md';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
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
}

interface FavoriteProps {
    character: Character;
}

const Favorite: React.FC<FavoriteProps> = ({ character }) => {
    const dispatch = useDispatch();
    const favorites = useSelector((state: RootState) => state.favorite.favorites);
    const isFavorite = favorites.includes(character.id);

    const handleFavoriteClick = () => {
        if (isFavorite) {
            Swal.fire({
                title: `${character.name} karakterini favorilerden kaldırmak istediğinize emin misiniz?`,
                showCancelButton: true,
                confirmButtonText: "Evet",
                cancelButtonText: "Hayır"
            }).then((result) => {
                if (result.isConfirmed) {
                    dispatch(removeFavorite(character.id));
                    toast.info(`${character.name} artık favori karakterin değil.`, {
                        position: "top-right",
                        autoClose: 3000,
                        hideProgressBar: false,
                        closeOnClick: true,
                        pauseOnHover: true,
                        draggable: true,
                        progress: undefined,
                        theme: "light",
                    });
                }
            });
        } else {
            if (favorites.length >= 10) {
                toast.info('Favori karakter ekleme sınırını aştınız. Başka bir karakteri favorilerden çıkarmalısınız.', {
                    position: "top-right",
                    autoClose: 5000,
                    hideProgressBar: false,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                    theme: "light",
                });
            } else {
                dispatch(addFavorite(character.id));
                toast.info(`${character.name} artık favorilerinde.`, {
                    position: "top-right",
                    autoClose: 3000,
                    hideProgressBar: false,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                    theme: "light",
                });
            }
        }
    };

    return (
        <button
            type="button"
            onClick={handleFavoriteClick}
            className="btn position-absolute top-0 end-0 p-1"
        >
            {isFavorite ? <MdFavorite size={30} color="red" /> : <MdFavoriteBorder size={30} color="red" />}
        </button>
    );
};

export default Favorite;
