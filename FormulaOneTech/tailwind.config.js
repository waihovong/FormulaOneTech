module.exports = {
    content: ["./**/.{razor,html,cshtml}",
        "C:/Users/61434/source/repos/FormulaOneTech/FormulaOneTech/Components/**/*.razor",
    ],
    theme: {
        extend: {
            fontFamily: {
                'sans': ['Poppins', 'sans-serif'],
            },
            colors: {
                alpine: "#FF87BC",
                aston_martin: "#229971",
                ferrari: "#E8002D",
                haas: "#B6BABD",
                mclaren: "#FF8000",
                mercedes: "#27F4D2",
                rb: "#6692FF",
                red_bull: "#3671C6",
                sauber: "#52E252",
                williams: "#64C4FF"
            }
        },
    },
    plugins: [],
}