package pl.opole.uni.lista3.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;

import java.util.List;
import java.util.Objects;

@Entity
public class RodzajKsiazki {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer rodzajKsiazkaID;
    private String symbol;
    private String nazwa;
    @JsonIgnore
    @OneToMany(mappedBy = "rodzajKsiazki")
    private List<Ksiazka> ksiazki;

    public Integer getRodzajKsiazkaID() {
        return rodzajKsiazkaID;
    }

    public void setRodzajKsiazkaID(Integer id) {
        this.rodzajKsiazkaID = id;
    }

    public String getSymbol() {
        return symbol;
    }

    public void setSymbol(String symbol) {
        this.symbol = symbol;
    }

    public String getNazwa() {
        return nazwa;
    }

    public void setNazwa(String nazwa) {
        this.nazwa = nazwa;
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
        RodzajKsiazki that = (RodzajKsiazki) o;
        return Objects.equals(rodzajKsiazkaID, that.rodzajKsiazkaID);
    }

    @Override
    public int hashCode() {
        return Objects.hash(rodzajKsiazkaID);
    }
}
