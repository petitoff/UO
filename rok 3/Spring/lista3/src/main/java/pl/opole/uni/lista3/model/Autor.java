package pl.opole.uni.lista3.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;

import java.util.List;
import java.util.Objects;

@Entity
public class Autor {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer autorID;
    private String Imie;
    private String nazwisko;
    @JsonIgnore
    @ManyToMany(mappedBy = "autors")
    private List<Ksiazka> ksiazki;

    public Integer getAutorID() {
        return autorID;
    }

    public void setAutorID(Integer id) {
        this.autorID = id;
    }

    public String getImie() {
        return Imie;
    }

    public void setImie(String imie) {
        Imie = imie;
    }

    public String getNazwisko() {
        return nazwisko;
    }

    public void setNazwisko(String nazwisko) {
        this.nazwisko = nazwisko;
    }

    public List<Ksiazka> getKsiazki() {
        return ksiazki;
    }

    public void setKsiazki(List<Ksiazka> ksiazki) {
        this.ksiazki = ksiazki;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Autor autor = (Autor) o;
        return Objects.equals(autorID, autor.autorID);
    }

    @Override
    public int hashCode() {
        return Objects.hash(autorID);
    }
}
