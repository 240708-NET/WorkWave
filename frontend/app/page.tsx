import Image from "next/image";
import styles from "./page.module.css";
import NavBar from "@/app/components/NavBar/NavBar"
import Column from "@/app/components/Column/Column"

export default function Home() {
  return (
    <main className={styles.main}>
     
     <NavBar/>
     <Column />


    </main>
  );
}
