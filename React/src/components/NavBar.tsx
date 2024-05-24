import Link from 'next/link';
import Image from 'next/image';

export default function NavBar() {
    return (
        <nav className="navbar navbar-expand-lg bg-body-tertiary fixed-top shadow-lg">
            <div className="container-fluid">
                <Link className="navbar-brand" href="/" passHref>
                    <Image
                        src="/images/icon-144x144.png"
                        width={40}
                        height={40}
                        alt="Logo"
                    />
                </Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mx-auto mb-2 mb-lg-0">
                        <li className="nav-item">
                            <Link className="nav-link active" href="/" passHref>
                                Home
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" href="/episodes/" passHref>
                                Episodes
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" href="/characters/" passHref>
                                Characters
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" href="/favorites/" passHref>
                                Favorites
                            </Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
};