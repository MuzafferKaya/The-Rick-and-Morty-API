import React from 'react';
import Link from 'next/link';

interface PaginationProps  {
    info: {
        count: number;
        pages: number;
        next: string | null;
        prev: string | null;
    };
    currentPage: number;
    basePath: string;
    onPageChange: (page: number) => void;
};

const Pagination: React.FC<PaginationProps> = ({ info, currentPage, basePath, onPageChange }) => {
    const handlePageClick = (page: number) => {
        onPageChange(page);
    };

    const renderPageNumbers = () => {
        const totalPages = info.pages;
        const maxPageNumbersToShow = 5;
        const delta = Math.floor(maxPageNumbersToShow / 2);

        let startPage = Math.max(1, currentPage - delta);
        let endPage = Math.min(totalPages, currentPage + delta);

        if (currentPage - 1 <= delta) {
            endPage = Math.min(totalPages, maxPageNumbersToShow);
        }

        if (totalPages - currentPage <= delta) {
            startPage = Math.max(1, totalPages - maxPageNumbersToShow + 1);
        }

        const pageNumbers: (number | string)[] = [];
        if (startPage > 1) {
            pageNumbers.push(1);
            if (startPage > 2) {
                pageNumbers.push('...');
            }
        }

        for (let i = startPage; i <= endPage; i++) {
            pageNumbers.push(i);
        }

        if (endPage < totalPages) {
            if (endPage < totalPages - 1) {
                pageNumbers.push('...');
            }
            pageNumbers.push(totalPages);
        }

        return pageNumbers.map((page, index) =>
            typeof page === 'string' ? (
                <li className="page-item disabled" key={index}>
                    <span className="page-link">...</span>
                </li>
            ) : (
                <li className={`page-item ${page === currentPage ? 'active' : ''}`} key={index}>
                    <Link className="page-link" href={`${basePath}?page=${page}`} onClick={() => handlePageClick(page)} passHref>
                        {page}
                    </Link>
                </li>
            )
        );
    };

    return (
        <nav aria-label="Page navigation example">
            <ul className="pagination justify-content-center">
                <li className={`page-item ${info.prev == null ? 'disabled' : ''}`}>
                    <Link className="page-link" href={`${basePath}?page=${currentPage - 1}`} onClick={() => handlePageClick(currentPage - 1)} passHref>
                        Previous
                    </Link>
                </li>
                {renderPageNumbers()}
                <li className={`page-item ${info.next == null ? 'disabled' : ''}`}>
                    <Link className="page-link" href={`${basePath}?page=${currentPage + 1}`} onClick={() => handlePageClick(currentPage + 1)} passHref>
                        Next
                    </Link>
                </li>
            </ul>
        </nav>
    );
};

export default Pagination;