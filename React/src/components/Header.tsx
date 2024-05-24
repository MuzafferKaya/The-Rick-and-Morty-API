import Style from "@/styles/page.module.css";

export default function Header() {
    return (
        <div className={`bg-body-tertiary d-flex justify-content-center align-items-center my-5 shadow ${Style.header}`}>
            <div className="container text-center text-black-50">
                <h1 className="fw-bold display-1">The Rick and Morty Wiki</h1>
            </div>
        </div>
    );
}