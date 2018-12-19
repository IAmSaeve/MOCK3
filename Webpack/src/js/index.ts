// Import
import axios, { } from "../../node_modules/axios/index";

// Variables
const coinTable: HTMLTableElement = document.getElementById("coinTable") as HTMLTableElement;

const getbtn: HTMLButtonElement = document.getElementById("getAllCoinsButton") as HTMLButtonElement;
const postbtn: HTMLButtonElement = document.getElementById("postCoin") as HTMLButtonElement;
const getOnebtn: HTMLButtonElement = document.getElementById("getACoin") as HTMLButtonElement;

const getIdInput: HTMLInputElement = document.getElementById("coinId") as HTMLInputElement;

const postCoinIdInput: HTMLInputElement = document.getElementById("postCoinId") as HTMLInputElement;
const postCoinGenstandInput: HTMLInputElement = document.getElementById("postCoinGenstand") as HTMLInputElement;
const postCoinBudInput: HTMLInputElement = document.getElementById("postCoinBud") as HTMLInputElement;
const postCoinNavnInput: HTMLInputElement = document.getElementById("postCoinNavn") as HTMLInputElement;

// URL to server
const uri: string = "https://easj-mock2-2018.azurewebsites.net/api/coin/";

// Event listeners
getbtn.addEventListener("click", ShowAllCoins);
getOnebtn.addEventListener("click", ShowACoin);
postbtn.addEventListener("click", PostCoin);

function ShowAllCoins() {
    axios.get<ICoin[]>(uri)
        .then((response) => {
            // Clears list on button press
            coinTable.innerHTML = "";

            // Loop data in array and add to HTML table
            response.data.forEach((c: ICoin) => {
                const row = coinTable.insertRow();

                const ID = row.insertCell();
                const GENSTAND = row.insertCell();
                const BUD = row.insertCell();
                const NAVN = row.insertCell();

                ID.innerText = c.id.toString();
                GENSTAND.innerText = c.genstand.toString();
                BUD.innerText = c.bud.toString();
                NAVN.innerText = c.navn.toString();
            });
        }).catch((error) => {
            console.error(error);
        });
}

function ShowACoin() {
    axios.get<ICoin>(uri + getIdInput.valueAsNumber)
        .then((response) => {
            // Clears list on button press
            coinTable.innerHTML = "";

            // Loop data in array and add to HTML table
            const c: ICoin = response.data;
            const row = coinTable.insertRow();

            const ID = row.insertCell();
            const GENSTAND = row.insertCell();
            const BUD = row.insertCell();
            const NAVN = row.insertCell();

            ID.innerText = c.id.toString();
            GENSTAND.innerText = c.genstand.toString();
            BUD.innerText = c.bud.toString();
            NAVN.innerText = c.navn.toString();
        }).catch((error) => {
            console.error(error);
        });
}

function PostCoin() {
    // Construct data to send
    const data: ICoin = {
        id: postCoinIdInput.valueAsNumber,
        genstand: postCoinGenstandInput.value,
        bud: postCoinBudInput.valueAsNumber,
        navn: postCoinNavnInput.value,
    };

    // Send data
    axios.post(uri, data).catch((error) => console.error(error));

    // Clear input fields
    postCoinIdInput.value = "";
    postCoinGenstandInput.value = "";
    postCoinBudInput.value = "";
    postCoinNavnInput.value = "";
}

// Coin interface
interface ICoin {
    id: number;
    genstand: string;
    bud: number;
    navn: string;
}
