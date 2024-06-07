package pl.opole.uni.lista3.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;

import java.util.Date;
import java.util.List;
import java.util.Objects;

@Entity
public class Sprzedaz {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer sprzedazID;
    private Date date;

    @ManyToOne
    @JoinColumn(name="ksiazka")
    private Ksiazka ksiazka;
    private Integer ilosc;
    private Double cena;

    public Integer getSprzedazID() {
        return sprzedazID;
    }

    public void setSprzedazID(Integer sprzedazID) {
        this.sprzedazID = sprzedazID;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public Ksiazka getKsiazka() {
        return ksiazka;
    }

    public void setKsiazka(Ksiazka ksiazka) {
        this.ksiazka = ksiazka;
    }

    public Integer getIlosc() {
        return ilosc;
    }

    public void setIlosc(Integer ilosc) {
        this.ilosc = ilosc;
    }

    public Double getCena() {
        return cena;
    }

    public void setCena(Double cena) {
        this.cena = cena;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Sprzedaz sprzedaz = (Sprzedaz) o;
        return Objects.equals(sprzedazID, sprzedaz.sprzedazID);
    }

    @Override
    public int hashCode() {
        return Objects.hash(sprzedazID);
    }
}
