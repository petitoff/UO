package pl.opole.uni.lista3.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import org.springframework.web.bind.annotation.Mapping;

import java.util.List;
import java.util.Objects;

@Entity
public class Ksiazka {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer ksiazkaID;
    @ManyToOne
    @JoinColumn(name="rodzaj")
    private RodzajKsiazki rodzajKsiazki;
    private String tytul;
    private String opis;
    private Double Cena;
    private Integer stan;
    @ManyToMany
    @JoinTable(name="ksiazka_autor", joinColumns = {@JoinColumn(name = "ksiazkaID")},inverseJoinColumns = {@JoinColumn(name = "autorID")})
    private List<Autor> autors;

    @JsonIgnore
    @OneToMany(mappedBy = "ksiazka")
    private List<Sprzedaz> sprzedazList;

    public Integer getKsiazkaID() {
        return ksiazkaID;
    }

    public void setKsiazkaID(Integer ksiazkaID) {
        this.ksiazkaID = ksiazkaID;
    }

    public RodzajKsiazki getRodzajKsiazki() {
        return rodzajKsiazki;
    }

    public void setRodzajKsiazki(RodzajKsiazki rodzajKsiazki) {
        this.rodzajKsiazki = rodzajKsiazki;
    }

    public String getTytul() {
        return tytul;
    }

    public void setTytul(String tytul) {
        this.tytul = tytul;
    }

    public String getOpis() {
        return opis;
    }

    public void setOpis(String opis) {
        this.opis = opis;
    }

    public Double getCena() {
        return Cena;
    }

    public void setCena(Double cena) {
        Cena = cena;
    }

    public Integer getStan() {
        return stan;
    }

    public void setStan(Integer stan) {
        this.stan = stan;
    }

    public List<Autor> getAutors() {
        return autors;
    }

    public void setAutors(List<Autor> autors) {
        this.autors = autors;
    }

    public List<Sprzedaz> getSprzedazList() {
        return sprzedazList;
    }

    public void setSprzedazList(List<Sprzedaz> sprzedazList) {
        this.sprzedazList = sprzedazList;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Ksiazka ksiazka = (Ksiazka) o;
        return Objects.equals(ksiazkaID, ksiazka.ksiazkaID);
    }

    @Override
    public int hashCode() {
        return Objects.hash(ksiazkaID);
    }
}
