import React, { useEffect, useState } from 'react';
import { NavLink, useLocation, useSearchParams } from 'react-router-dom';
import "./Pagination.css"

interface Props {
    allPagesNumber: number
    itemsPerPage: number
    itemsNumber: number
    pageChange: (page: number) => void
}

interface Style {
    opacity: number
    backgroundColor?: string
    color?: string
}

const Pagination: React.FC<Props> = ({ allPagesNumber, itemsPerPage, itemsNumber, pageChange }) => {
    const path = useLocation();
    const pages:number[] = [];
    const [searchParams] = useSearchParams();
    const test: number | any = searchParams.get('page')
    const [currentPage, setCurrentPage] = useState<number>(test !== null ? parseInt(test) : 1);

    for (let index = 1; index <= allPagesNumber; index++) {
        pages.push(index)
    }

    useEffect(() => {
        pageChange(currentPage)
    }, [currentPage])


    const onFirstPage = (): void => {
        setCurrentPage(1);
    }

    const onLastPage = (): void => {
        setCurrentPage(allPagesNumber);
    }

    const onNextPage = (): void => {
        setCurrentPage(currentPage + 1);
    }

    const onPreviousPage = (): void => {
        setCurrentPage(currentPage - 1);
    }

    // const validateInput = (value: string) => {
    //     const regex = /^[0-9\b]+$/
    //     const regexTest = regex.test(value)
    //     regexTest && setCurrentPage(parseInt(value, 10))
    // }

    const stylingFirst = (): Style => {
        if (currentPage === 1) {
            return { opacity: 0.4 }
        }
        return { opacity: 1 }
    }

    const stylingPage = (page: number): Style => {
        if (currentPage === page) {
            return { opacity: 1, backgroundColor: "#c60c30", color: "white"}
        }
        return { opacity: 0.4 }
    }

    const stylingLast = (): Style => {
        if (currentPage === allPagesNumber) {
            return { opacity: 0.4 }
        }
        return { opacity: 1 }
    } 

    return (
        <div className="pagination_container">
            {/* <button
                className={`pagination_button pagination__page-first ${currentPage === 1 ? 'pagination__button--disabled' : ''}`}
                style={stylingFirst()}
                onClick={() => onFirstPage()}>
                First
            </button> */}
            <button
                className="page-button"
                style={stylingFirst()}
                onClick={() => onPreviousPage()}>
                {'<'}
            </button>
            {pages.map(page =>
                <NavLink to={`${path.pathname}?page=${page}`} key={page}>
                    <button
                        className="page-button"
                        style={stylingPage(page)}
                        onClick={() => setCurrentPage(page)}>
                        {page}
                    </button>
                </NavLink>
            )}
            <button
                className="page-button"
                style={stylingFirst()}
                onClick={() => onNextPage()}>
                {'>'}
            </button>
            {/* <button
                className={`pagination__button pagination__page-last ${currentPage === allPagesNumber && ' pagination__button--disabled'}`}
                onClick={() => onLastPage()}
                style={stylingLast()}>
                Last
            </button> */}
        </div>
    )
}

export default Pagination;