package pl.opole.uni.lista1.model;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;

@Entity
@Table(name="samochod")
public class Samochod extends Pojazd{
    private String rodzaj;
    private String tapicerka;
    private String strona_kierownicy;

    public String getRodzaj() {
        return rodzaj;
    }

    public void setRodzaj(String rodzaj) {
        this.rodzaj = rodzaj;
    }

    public String getTapicerka() {
        return tapicerka;
    }

    public void setTapicerka(String tapicerka) {
        this.tapicerka = tapicerka;
    }

    public String getStrona_kierownicy() {
        return strona_kierownicy;
    }

    public void setStrona_kierownicy(String strona_kierownicy) {
        this.strona_kierownicy = strona_kierownicy;
    }
}
