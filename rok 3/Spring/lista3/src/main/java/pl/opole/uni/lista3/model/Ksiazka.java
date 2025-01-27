package pl.opole.uni.lista3.model;

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
    @ManyToMany
    @JoinTable(name="ksiazka_autor", joinColumns = {@JoinColumn(name = "ksiazkaID")},inverseJoinColumns = {@JoinColumn(name = "autorID")})
    private List<Autor> autors;

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

    public List<Autor> getAutors() {
        return autors;
    }

    public void setAutors(List<Autor> autors) {
        this.autors = autors;
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
